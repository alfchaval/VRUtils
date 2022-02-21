using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//This class contains useful static methods that are not tied to specifics mechanics
public class Utils
{ 
    //Return the distance between two points, ignoring the Y axis
    public static float HorizontalDistance(Vector3 v1, Vector3 v2)
	{
		return Mathf.Sqrt(Mathf.Pow(v1.x - v2.x, 2) + Mathf.Pow(v1.z - v2.z, 2));
	}
	
    //Return the nearest component T to a point, the object with that component needs a Collider to be detected.
    //This method is expensive, use only for small areas
	public static T GetNearest<T>(Transform t, float maxDistance) where T : MonoBehaviour
    {
        List<T> nearTs = GetNear<T>(t.position, maxDistance);
        if (nearTs.Count == 0)
        {
            return null;
        }
        T[] orderedTs = nearTs.OrderBy(c => Vector3.Distance(t.position, c.transform.position)).ToArray();
        return orderedTs[0];
    }

    //Return all components T near to a point, the objects with that component need a Collider to be detected.
    //This method is expensive, use only for small areas
    public static List<T> GetNear<T>(Vector3 p, float maxDistance) where T : MonoBehaviour
    {
        List<T> nearTs = new List<T>();
        Collider[] nearColliders = Physics.OverlapSphere(p, maxDistance);
        T aux;
        for (int i = 0; i < nearColliders.Length; i++)
        {
            aux = nearColliders[i].GetComponent<T>();
            if (aux)
            {
                nearTs.Add(aux);
            }
        }
        return nearTs;
    }

    //Cast a ray ignoring all GameObjects with an specific component
    //This method use a RaycastAll, try to avoid using Mathf.Infinity as the maxDistance parameter
    //If checkParents is true, it also ignore children of GameObjects with that component
    public static bool RayCastIgnoring<T>(Vector3 origin, Vector3 direction, out RaycastHit resultHit, float maxDistance, bool checkParents) where T : MonoBehaviour
    {
        RaycastHit[] hits = Physics.RaycastAll(origin, direction, maxDistance);
        if (hits.Length > 0)
        {
            if (checkParents)
            {
                hits = hits.Where(hit => !hit.transform.GetComponentInParent<T>()).ToArray();
            }
            else
            {
                hits = hits.Where(hit => !hit.transform.GetComponent<T>()).ToArray();
            }
            if (hits.Length > 0)
            {
                if (hits.Length > 1)
                {
                    hits = hits.OrderBy(hit => hit.distance).ToArray();
                }
                resultHit = hits[0];
                return true;
            }
        }
        resultHit = new RaycastHit();
        return false;
    }

    //Cast a ray ignoring specifics Transforms
    //This method use a RaycastAll, try to avoid using Mathf.Infinity as the maxDistance parameter
    public static bool RayCastIgnoringTransforms(Transform[] transformsToIgnore, Vector3 origin, Vector3 direction, out RaycastHit resultHit, float maxDistance)
    {
        RaycastHit[] hits = Physics.RaycastAll(origin, direction, maxDistance);
        if (hits.Length > 0)
        {
            hits = hits.Where(hit => transformsToIgnore.Contains(hit.transform)).ToArray();
            if (hits.Length > 1)
            {
                hits = hits.OrderBy(hit => hit.distance).ToArray();
                resultHit = hits[0];
                return true;
            }
        }
        resultHit = new RaycastHit();
        return false;
    }

    //Shuffle a list
    public static void ShuffleList<T>(List<T> listToShuffle)
    {
        int numberOfTransforms = listToShuffle.Count;
        T auxT;
        int randomIndex;
        for (int i = 0; i < numberOfTransforms; i++)
        {
            auxT = listToShuffle[i];
            randomIndex = Random.Range(i, numberOfTransforms);
            listToShuffle[i] = listToShuffle[randomIndex];
            listToShuffle[randomIndex] = auxT;
        }
    }

    //Shuffle an array
    public static void ShuffleArray<T>(T[] listToShuffle)
    {
        int numberOfTransforms = listToShuffle.Length;
        T auxT;
        int randomIndex;
        for (int i = 0; i < numberOfTransforms; i++)
        {
            auxT = listToShuffle[i];
            randomIndex = Random.Range(i, numberOfTransforms);
            listToShuffle[i] = listToShuffle[randomIndex];
            listToShuffle[randomIndex] = auxT;
        }
    }

    //Exchange the position of a list of Transforms at random 
    public static void ShuffleTransforms(List<Transform> list, bool changeRotation = true)
    {
        int numberOfTransforms = list.Count;
        List<Vector3> positions = new List<Vector3>();
        List<Vector3> rotations = new List<Vector3>();
        for (int i = 0; i < numberOfTransforms; i++)
        {
            positions.Add(list[i].position);
            rotations.Add(list[i].eulerAngles);
        }
        ShuffleList(list);
        for (int i = 0; i < numberOfTransforms; i++)
        {
            list[i].position = positions[i];
            if (changeRotation)
            {
                list[i].eulerAngles = rotations[i];
            }
        }
    }

    //Return the equivalent angle to currentAngle closest to otherAngle
    public static float CloserAngle(float currentAngle, float otherAngle)
    {
        float resultAngle = currentAngle;
        resultAngle -= 360 * (int)((resultAngle - otherAngle) / 360);
        int angledistance = (int)((resultAngle - otherAngle) / 180);
        if (angledistance != 0)
        {
            resultAngle -= 360 * angledistance;
        }
        return resultAngle;
    }

    //Return the equivalent angle to currentAngle with the minimum value
    public static float ReduceAngle(float currentAngle, bool makePositive = false)
    {
        float resultAngle = currentAngle;
        resultAngle -= 360 * (int)(resultAngle / 360);
        if (makePositive && resultAngle < 0)
        {
            resultAngle += 360;
        }
        return resultAngle;
    }

    //It does the same as Transform.TransformPoint(Vector3 p), but ignoring the scale
    public static Vector3 TransformPointUnscaled(Transform transform, Vector3 position)
    {
        return transform.position + transform.rotation * position;
    }

    //It does the same as Transform.InverseTransformPoint(Vector3 p), but ignoring the scale
    public static Vector3 InverseTransformPointUnscaled(Transform transform, Vector3 position)
    {
        position -= transform.position;
        return Quaternion.Inverse(transform.rotation) * position;
    }
}
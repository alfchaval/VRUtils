using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    public Transform rayOrigin;
	public float snapDistance = 2;
    public float grabForce = 1;
    public float releaseForce = 1;
    
    private Grabbable grabbedObject;
    private Grabbable pullingObject;

    private bool pullStarted = false;

    public void Pull()
    {
        if (!grabbedObject)
        {
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin.position, rayOrigin.transform.forward, out hit, Mathf.Infinity))
            {
                pullingObject = hit.transform.GetComponent<Grabbable>();
                if (pullingObject && !pullingObject.grabbingHand && pullingObject.GetComponent<Rigidbody>().useGravity && !pullingObject.GetComponent<Rigidbody>().isKinematic)
                {
                    pullStarted = true;
                    pullingObject.canBeGrabbed = false;
                }
            }
        }
    }

    public void Pulling()
    {
        if (pullingObject && !grabbedObject)
        {
            if (pullingObject.grabbingHand)
            {
                pullingObject.grabbingHand.UnGrab();
            }
            if (Vector3.Dot(Vector3.Normalize(pullingObject.transform.position - rayOrigin.position - rayOrigin.forward * snapDistance), rayOrigin.transform.forward) <= 0)
            {
                grabbedObject = pullingObject;
                grabbedObject.transform.position = rayOrigin.transform.position;
                grabbedObject.transform.parent = rayOrigin.transform;
                grabbedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                grabbedObject.GetComponent<Rigidbody>().useGravity = false;
                grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                pullingObject = null;
                pullStarted = false;
            }
            else
            {
                pullingObject.GetComponent<Rigidbody>().AddForce(-rayOrigin.transform.forward * grabForce, ForceMode.Acceleration);
            }
        }
    }

    public void Push()
    {
        pullStarted = false;
        if (grabbedObject)
        {
            grabbedObject.canBeGrabbed = true;
            grabbedObject.GetComponent<Rigidbody>().useGravity = true;
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObject.GetComponent<Rigidbody>().AddForce(rayOrigin.transform.forward * releaseForce, ForceMode.VelocityChange);
            grabbedObject.transform.parent = null;
            grabbedObject = null;
        }
    }

    public void ReleaseObject()
    {
        pullStarted = false;
        if (grabbedObject)
        {
            grabbedObject.canBeGrabbed = true;
            grabbedObject.GetComponent<Rigidbody>().useGravity = true;
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObject.transform.parent = null;
            grabbedObject = null;
        }
    }

    private void Update()
    {
        if (pullStarted)
        {
            Pulling();
        }
    }
}

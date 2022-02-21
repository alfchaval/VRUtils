using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public Transform needle;
    public float needleSpeed;
    public CompassMode mode;
    public Vector3 targetDirection;
    public Transform targetTransform;
    public bool blocked = false;

    private void Update()
    {
        if (!blocked)
        {
            switch (mode)
            {
                case CompassMode.Direction:
                    MoveNeedle(targetDirection);
                    break;
                case CompassMode.Transform:
                    if (targetTransform)
                    {
                        MoveNeedle(targetTransform.position - transform.position);
                    }
                    break;
            }
        }
    }

    private void MoveNeedle(Vector3 compassTargetDirection)
    {
        if (compassTargetDirection != Vector3.zero)
        {
            Vector3 needleTargetDirection = Vector3.ProjectOnPlane(compassTargetDirection, transform.up);
            //Debug.DrawLine(needle.transform.position, needleTargetDirection, Color.red, 1f);
            Quaternion needleTargetRotation = Quaternion.LookRotation(needleTargetDirection, transform.up);
            needle.transform.rotation = Quaternion.Lerp(needle.transform.rotation, needleTargetRotation, needleSpeed * Time.deltaTime);
        }
    }

    public enum CompassMode
    {
        Direction,
        Transform
    }
}

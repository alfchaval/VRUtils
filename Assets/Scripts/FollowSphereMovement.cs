using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSphereMovement : FollowMovement
{
    public Transform centerTransform;
    public Scope centerScope = Scope.Local;

    private Vector3 startingPosition;
    private Quaternion startingRotation;

    protected override void Start()
    {
        base.Start();
        if (!centerTransform)
        {
            centerTransform = transform;
        }
    }

    private void Update()
    {
        if (transformToFollow)
        {
            Vector3 centerToStartingPosition = startingFollowPosition - centerTransform.position;
            Vector3 centerToTransformToFollow = transformToFollow.position - centerTransform.position;
            Vector3 axis = Vector3.Cross(centerToStartingPosition, centerToTransformToFollow);
            Quaternion rotationMovement = Quaternion.AngleAxis(Vector3.SignedAngle(centerToStartingPosition, centerToTransformToFollow, axis), axis);
            transform.rotation *= rotationMovement;
            //transform.position = centerTransform.position + rotationMovement * (startingPosition - centerTransform.position);
            startingFollowPosition = transformToFollow.position;
            Debug.DrawRay(centerTransform.position, centerToTransformToFollow, Color.red);
        }
    }

    public override void Follow(Transform t)
    {
        base.Follow(t);
        startingPosition = transform.position;
        startingRotation = transform.rotation;
    }
    /*
    private void Update()
    {
        if (transformToFollow)
        {
            Vector3 centerToStartingPosition = startingFollowPosition - centerTransform.position;
            Vector3 centerToTransformToFollow = transformToFollow.position - centerTransform.position;
            Quaternion rotationMovement = Quaternion.FromToRotation(centerToStartingPosition, centerToTransformToFollow);
            transform.rotation = startingRotation * rotationMovement;
            transform.position = centerTransform.position + rotationMovement * (startingPosition - centerTransform.position);
        }
    }

    public override void Follow(Transform t)
    {
        base.Follow(t);
        startingPosition = transform.position;
        startingRotation = transform.rotation;
    }
    */
}


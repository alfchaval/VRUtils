using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAngularMovement : FollowMovement
{
    public Transform axisTransform;
    public Vector3 axisDirection = Vector3.up;
    public Scope axisScope = Scope.Local;
    [Range(0, 180)]
    public float limitPositiveAngle = 90;
    [Range(-180, 0)]
    public float limitNegativeAngle = -90;

    private Quaternion originRotation;
    private float startingAngleFromOrigin = 0;

    protected override void Start()
    {
        base.Start();
        originRotation = transform.rotation;
        if (!axisTransform)
        {
            axisTransform = transform;
        }
    }

    private void Update()
    {
        if (transformToFollow)
        {
            Vector3 globalMovementAxis = axisScope == Scope.Global ? axisDirection : axisTransform.TransformDirection(axisDirection);
            Vector3 axisToStartingPosition = Vector3.ProjectOnPlane(startingFollowPosition - axisTransform.position, globalMovementAxis);
            Vector3 axisToTransformToFollow = Vector3.ProjectOnPlane(transformToFollow.position - axisTransform.position, globalMovementAxis);
            float angle = Vector3.SignedAngle(axisToStartingPosition, axisToTransformToFollow, globalMovementAxis);
            Vector3 originPosition = transform.parent ? transform.parent.TransformPoint(originLocalPosition) : transform.position;
            Vector3 nearestPointToOriginInAxis = axisTransform.position + Vector3.Project(originPosition - axisTransform.position, globalMovementAxis);
            if (useLimits)
            {  
                if (startingAngleFromOrigin + angle > limitPositiveAngle)
                {
                    angle = limitPositiveAngle - startingAngleFromOrigin;
                }
                else if (startingAngleFromOrigin + angle < limitNegativeAngle)
                {
                    angle = limitNegativeAngle - startingAngleFromOrigin;
                }
            }
            transform.rotation = originRotation * Quaternion.AngleAxis(angle, globalMovementAxis);
            transform.position = nearestPointToOriginInAxis + Quaternion.AngleAxis(angle, globalMovementAxis) * (originPosition - nearestPointToOriginInAxis);
        }
    }

    public override void Follow(Transform t)
    {
        base.Follow(t);
        Vector3 globalMovementAxis = axisScope == Scope.Global ? axisDirection : axisTransform.TransformDirection(axisDirection);
        Vector3 originPosition = transform.parent ? transform.parent.TransformPoint(originLocalPosition) : transform.position;
        Vector3 axisToOriginPosition = Vector3.ProjectOnPlane(originPosition - axisTransform.position, globalMovementAxis);
        Vector3 axisToCurrentPosition = Vector3.ProjectOnPlane(transform.position - axisTransform.position, globalMovementAxis);
        startingAngleFromOrigin = Vector3.SignedAngle(axisToOriginPosition, axisToCurrentPosition, globalMovementAxis);
    }
}


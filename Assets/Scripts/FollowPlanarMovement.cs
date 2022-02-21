using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlanarMovement : FollowMovement
{
    public Vector3 movementNormal;
    public Scope movementScope;
    public float maxRadiusDistance;

    private void Update()
    {
        if (transformToFollow)
        {
            Vector3 globalMovementNormal = movementScope == Scope.Global ? movementNormal : transform.TransformDirection(movementNormal);
            Vector3 vectorFromOrigin = transformToFollow.position - startingFollowPosition;
            Vector3 projectedVectorFromOrigin = Vector3.ProjectOnPlane(vectorFromOrigin, globalMovementNormal);
            transform.position = originLocalPosition + projectedVectorFromOrigin;
            if (useLimits)
            {
                float distance = Vector3.Magnitude(projectedVectorFromOrigin);
                if (distance > maxRadiusDistance)
                {
                    transform.position = originLocalPosition + Vector3.Normalize(projectedVectorFromOrigin) * maxRadiusDistance;
                }
            }
        }
    }
}


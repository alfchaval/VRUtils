using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLinearMovement : FollowMovement
{
    public Vector3 movementDirection;
    public Scope movementScope;
    public float maxDistanceForward;
    public float maxDistanceBackwards;

    private void Update()
    {
        if (transformToFollow)
        {
            Vector3 globalMovementDirection = movementScope == Scope.Global ? movementDirection : transform.TransformDirection(movementDirection);
            Vector3 vectorFromOrigin = transformToFollow.position - startingFollowPosition;
            Vector3 projectedVectorFromOrigin = Vector3.Project(vectorFromOrigin, globalMovementDirection);
            transform.localPosition = originLocalPosition + projectedVectorFromOrigin;
            if (useLimits)
            {
                float distance = Vector3.Magnitude(projectedVectorFromOrigin);
                float dot = Vector3.Dot(Vector3.Normalize(globalMovementDirection), Vector3.Normalize(projectedVectorFromOrigin));
                if (dot > 0 && distance > maxDistanceForward)
                {
                    transform.localPosition = originLocalPosition + Vector3.Normalize(globalMovementDirection) * maxDistanceForward;
                }
                else if (dot < 0 && distance > maxDistanceBackwards)
                {
                    transform.localPosition = originLocalPosition - Vector3.Normalize(globalMovementDirection) * maxDistanceBackwards;
                }
            }
        }
    }
}


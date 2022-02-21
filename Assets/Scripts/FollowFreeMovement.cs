using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowFreeMovement : FollowMovement
{
    public float maxRadiusDistance;

    private void Update()
    {
        if (transformToFollow)
        {
            Vector3 vectorFromOrigin = transformToFollow.position - startingFollowPosition;
            transform.position = originLocalPosition + vectorFromOrigin;
            if (useLimits)
            {
                float distance = Vector3.Magnitude(vectorFromOrigin);
                if (distance > maxRadiusDistance)
                {
                    transform.position = originLocalPosition + Vector3.Normalize(vectorFromOrigin) * maxRadiusDistance;
                }
            }
        }
    }
}


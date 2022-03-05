using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public abstract class FollowMovement : MonoBehaviour
{
#if UNITY_EDITOR
    public Transform DEBUG_TRANSFORM;
#endif
    public bool useLimits = false;

    protected Vector3 originLocalPosition;
    protected Transform transformToFollow;
    protected Vector3 startingFollowPosition;

    protected virtual void Start()
    {
        originLocalPosition = transform.localPosition;
#if UNITY_EDITOR
        DEBUG();
#endif
    }

    public void Follow(Interactor interactor)
    {
        Follow(interactor.transform);
    }

    public virtual void Follow(Transform t)
    {
        transformToFollow = t;
        if (transformToFollow)
        {
            startingFollowPosition = transformToFollow.transform.position;
        }
    }

    public virtual void UnFollow()
    {
        transformToFollow = null;
    }

#if UNITY_EDITOR
    private void DEBUG()
    {
        Follow(DEBUG_TRANSFORM);
    }
#endif

    public enum Scope
    {
        Local,
        Global
    }
}


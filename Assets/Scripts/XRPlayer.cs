using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR.LegacyInputHelpers;
using UnityEngine;

[RequireComponent(typeof(CameraOffset))]
public class XRPlayer : MonoBehaviour
{
    public Transform rigOffset;
    public Camera head;
    public Hand rightHand;
    public Hand leftHand;

    private static XRPlayer instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        BindActions();
#if UNITY_EDITOR
        if (!rightHand || rightHand.type != Hand.HandType.Right)
        {
            Debug.LogError("Incorrect right hand setup", transform);
        }

        if (!leftHand || leftHand.type != Hand.HandType.Left)
        {
            Debug.LogError("Incorrect left hand setup", transform);
        }
#endif
    }
    public void BindActions()
    {
        ///XRInputsManager xrInputsManager = XRInputsManager.GetInstance();
    }

    public Vector3 ChestGuess()
    {
        return head.transform.position + (transform.position - head.transform.position) * 1 / 5;
    }

    public static XRPlayer GetInstance()
    {
        return instance;
    }
}

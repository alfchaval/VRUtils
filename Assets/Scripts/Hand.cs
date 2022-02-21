using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SpatialTracking;

[RequireComponent(typeof(TrackedPoseDriver))]
public class Hand : Interactor
{
    public HandType type { get; private set; }
    public XRPlayerMovement xrPlayerMovement;

    public bool canGrab = true;
    public Transform grabTransform;
    public float grabDistance = 0.1f;
    public Grabbable currentGrabbable { get; private set; }

    public bool canInteract = true;
    public Transform interactTransform;
    public float interactDistance = 0.1f;
    public SingleInteractable interacting { get; private set; }

    public Transform climbingTransform { get; private set; }
    public Vector3 climbingPosition { get; private set; }

    public bool triedGrab { get; private set; } = false;

    private void Awake()
    {
        switch (GetComponent<TrackedPoseDriver>().poseSource)
        {
            case TrackedPoseDriver.TrackedPose.RightPose:
                type = HandType.Right;
                break;
            case TrackedPoseDriver.TrackedPose.LeftPose:
                type = HandType.Left;
                break;
        }
    }

    private void Start()
    {
        BindActions();
    }

    public void BindActions()
    {
        XRInputsManager xrInputsManager = XRInputsManager.GetInstance();
        switch (type)
        {
            case HandType.Right:
                xrInputsManager.OnRightGripPressed.AddListener(Grab);
                xrInputsManager.OnRightGripReleased.AddListener(UnGrab);
                xrInputsManager.OnRightTriggerPressed.AddListener(StartInteraction);
                xrInputsManager.OnRightTriggerReleased.AddListener(EndInteraction);
                break;
            case HandType.Left:
                xrInputsManager.OnLeftGripPressed.AddListener(Grab);
                xrInputsManager.OnLeftGripReleased.AddListener(UnGrab);
                xrInputsManager.OnLeftTriggerPressed.AddListener(StartInteraction);
                xrInputsManager.OnLeftTriggerReleased.AddListener(EndInteraction);
                break;
        }
    }

    public void Grab()
    {
        triedGrab = true;
        if (canGrab)
        {
            TryGrab(GetGrabbable());
        }
        if (!currentGrabbable)
        {
            if (xrPlayerMovement)
            {
                if (xrPlayerMovement.canClimb)
                {
                    GetClimbingPoint();
                }
            }
#if UNITY_EDITOR
            else
            {
                print("No XRPlayerMovement assigned to Hand component in " + name);
            }
#endif
        }
    }

    public void Grab(Grabbable grabbable)
    {
        if (canGrab)
        {
            TryGrab(grabbable);
        }
    }

    private void TryGrab(Grabbable grabbable)
    {
        if (grabbable)
        {
            if (grabbable != currentGrabbable)
            {
                UnGrab();
                grabbable.Grabbed(this);
                currentGrabbable = grabbable;
            }
        }
    }

    public void UnGrab()
    {
        triedGrab = false;
        if(currentGrabbable)
		{
            if (interacting && interacting.transform == currentGrabbable.transform)
            {
                EndInteraction();
            }
            currentGrabbable.UnGrabbed(this);
			currentGrabbable = null;
		}
        climbingTransform = null;
    }

    public void StartInteraction()
    {
        if (canInteract)
        {
            SingleInteractable interactable = GetInteractable();
            if (interactable)
            {
                interacting = interactable;
                interactable.StartInteraction(this);
            }
        }
    }

    public void EndInteraction()
    {
        if (interacting)
        {
            interacting.EndInteraction(this);
            interacting = null;
        }
    }

    public Grabbable GetGrabbable()
    {
        if (currentGrabbable)
        {
            return currentGrabbable;
        }
        return Utils.GetNearest<Grabbable>(grabTransform, grabDistance);
    }

    public SingleInteractable GetInteractable()
    {
        if (currentGrabbable)
        {
            return currentGrabbable.GetComponent<SingleInteractable>();
        }
        return Utils.GetNearest<SingleInteractable>(interactTransform, interactDistance);
    }

    private void GetClimbingPoint()
    {
        if (xrPlayerMovement.climbOnEverything)
        {
            climbingPosition = transform.position;
        }
        else
        {
            Collider[] nearColliders = Physics.OverlapSphere(grabTransform.position, grabDistance);
            List<Transform> climbables = new List<Transform>();
            Rigidbody auxRB;
            for (int i = 0; i < nearColliders.Length; i++)
            {
                auxRB = nearColliders[i].GetComponent<Rigidbody>();
                if (!auxRB || auxRB.isKinematic)
                {
                    climbables.Add(nearColliders[i].transform);
                }
            }
            if (climbables.Count > 0)
            {
                Transform[] orderedClimbables = climbables.OrderBy(hit => hit.position).ToArray();
                climbingTransform = orderedClimbables[0];
                climbingPosition = climbingTransform.InverseTransformPoint(transform.position);
            }
        }
    }

#if UNITY_EDITOR
    public bool debugSpheres;

    private void OnDrawGizmos()
    {
        if (debugSpheres)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(grabTransform.position, grabDistance);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(interactTransform.position, interactDistance);
        }
    }
#endif

    public enum HandType
    {
        None,
        Right,
        Left
    }
}

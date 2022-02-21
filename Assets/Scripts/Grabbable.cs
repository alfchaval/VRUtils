using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Grabbable : MonoBehaviour
{
	public bool canBeGrabbed = true;
	public bool useAttachOffsets;
	public Vector3 uniquePositionOffset;
    public Vector3 mirrorPositionOffset;
    public Vector3 uniqueRotationOffset;
    public Vector3 mirrorRotationOffset;

	public UnityEvent<Hand> onAttach;
	public UnityEvent<Hand> onUnAttach;

	public Hand grabbingHand { get; protected set; }

	protected Rigidbody rigidBody;
	protected bool wasKinematic;
	protected bool usedGravity;
	protected bool physicsSaved;

    private void Awake()
    {
		rigidBody = GetComponent<Rigidbody>();
	}

    public virtual void Grabbed(Hand hand)
	{
		if(hand && canBeGrabbed)
		{
			if(grabbingHand)
			{
				grabbingHand.UnGrab();
			}
			grabbingHand = hand;
			Attach();
		}
	}
	
	public virtual void UnGrabbed(Hand hand)
	{
		if(hand && hand == grabbingHand)
		{
			UnAttach();
			grabbingHand = null;
		}
	}
	
	protected void Attach()
	{
		DisablePhysics();
		transform.parent = grabbingHand.transform;
		if(useAttachOffsets)
		{
			transform.position = grabbingHand.grabTransform.position;
			transform.eulerAngles = grabbingHand.grabTransform.eulerAngles;
			transform.localPosition += uniquePositionOffset;
			transform.localEulerAngles += uniqueRotationOffset;
			switch(grabbingHand.type)
			{
				case Hand.HandType.Right:
					transform.localPosition += mirrorPositionOffset;
					transform.localEulerAngles += mirrorRotationOffset;
					break;
				case Hand.HandType.Left:
					transform.localPosition -= mirrorPositionOffset;
					transform.localEulerAngles -= mirrorRotationOffset;
					break;
			}
		}
		onAttach.Invoke(grabbingHand);
	}
	
	protected void UnAttach()
	{
		RestorePhysics();
		transform.parent = null;
		onUnAttach.Invoke(grabbingHand);
	}

	public void DisablePhysics()
	{
		if (!physicsSaved)
		{
			wasKinematic = rigidBody.isKinematic;
			usedGravity = rigidBody.useGravity;
			rigidBody.isKinematic = true;
			rigidBody.useGravity = false;
			physicsSaved = true;
		}
	}

	public void RestorePhysics()
	{
		if (physicsSaved)
		{
			rigidBody.isKinematic = wasKinematic;
			rigidBody.useGravity = usedGravity;
			physicsSaved = false;
		}
	}
}

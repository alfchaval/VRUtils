using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(XRPlayer))]
public class XRPlayerMovement : MonoBehaviour
{
    public XRPlayer xrPlayer;

    public MovementSystem movementSystem;
    public float horizontalDisplacementSpeed = 5;
    public float verticalDisplacementSpeed = 2;
    public float cameraRotationSpeed = 90;
    public MovementType forwardDisplacement = MovementType.CameraRotationBased;
    public MovementType lateralDisplacement = MovementType.CameraRotationBased;
    public MovementType verticalDisplacement = MovementType.WorldBased;
    public float stepHeight = 1;
    public float playerRadiusLength = 0.3f;
    public float diveSpeed = 3;
    public bool followHead = true;
    public bool canClimb = true;
    public bool climbOnEverything = false;
    public bool canJump = true;
    public float jumpForce = 10.0f;
    private bool jumping = false;
    private bool landedJump = true;
#if UNITY_EDITOR
    public bool debugRays;
#endif

    private float lastHandDistance;
    private MovementSystem lastMovement;
    private Transform floor;
    private Vector3 lastFloorPosition;

    private void Start()
    {
        XRInputsManager xrInputsManager = XRInputsManager.GetInstance();
        xrInputsManager.OnRightJoyStickPressed.AddListener(StartJump);
    }

    private void Update()
    {
        if (xrPlayer)
        {
            if (IsClimbing())
            {
                ClimbingMovement();
            }
            else
            {
                switch (movementSystem)
                {
                    case MovementSystem.Walk:
                        WalkMovement();
                        break;
                    case MovementSystem.Flying:
                        FlyingMovement();
                        break;
                    case MovementSystem.Diving:
                        DivingMovement();
                        break;
                    case MovementSystem.ArmSwing:
                        ArmSwingMovement();
                        break;
                }

                lastMovement = movementSystem;
            }
        }
#if UNITY_EDITOR
        else
        {
            print("No XRPlayer assigned to XRPlayerMovement component in " + transform.name);
        }
#endif
    }

    private void WalkMovement()
    {
        if (followHead)
        {
            FollowHead();
        }

        CheckFloorMovement();
        ApplyDisplacement(GetJoyStickForward() + GetJoyStickLateral(), true);
        JoyStickRotation();
        CheckFall();
    }

    private void FlyingMovement()
    {
        if (followHead)
        {
            FollowHead();
        }

        ApplyDisplacement(GetJoyStickForward() + GetJoyStickLateral() + GetJoyStickVertical(), false);
        JoyStickRotation();
    }

    private void DivingMovement()
    {
        if (followHead)
        {
            FollowHead();
        }

        Dive();
        JoyStickRotation();
    }

    private bool IsClimbing()
    {
        return canClimb &&
               ((xrPlayer.rightHand.triedGrab && (xrPlayer.rightHand.climbingTransform || climbOnEverything)) ||
                (xrPlayer.leftHand.triedGrab && (xrPlayer.leftHand.climbingTransform || climbOnEverything)));
    }

    private void ClimbingMovement()
    {
        Vector3 rightHandPoint;
        Vector3 leftHandPoint;
        if (IsHandClimbing(xrPlayer.rightHand, out rightHandPoint))
        {
            if (IsHandClimbing(xrPlayer.leftHand, out leftHandPoint))
            {
            }
            else
            {
                transform.position += rightHandPoint - xrPlayer.rightHand.transform.position;
            }
        }
        else if (IsHandClimbing(xrPlayer.leftHand, out leftHandPoint))
        {
            transform.position += leftHandPoint - xrPlayer.leftHand.transform.position;
        }
    }

    private bool IsHandClimbing(Hand hand, out Vector3 climbingPoint)
    {
        if (hand.triedGrab)
        {
            if (climbOnEverything)
            {
                climbingPoint = hand.climbingPosition;
                return true;
            }
            else if (hand.climbingTransform)
            {
                climbingPoint = hand.climbingTransform.TransformPoint(hand.climbingPosition);
                return true;
            }
        }

        climbingPoint = Vector3.zero;
        return false;
    }

    private void ArmSwingMovement()
    {
    }

    private void TeleportMovement()
    {
    }

    private void StartJump()
    {
        if (canJump && fallingSpeed < 0.01f && landedJump)
        {
            StartCoroutine(Jump());
        }
    }

    private IEnumerator Jump()
    {
        jumping = true;
        landedJump = false;
        float remainingJumpTime = 0.5f;
        while (remainingJumpTime > 0)
        {
            xrPlayer.transform.Translate(Vector3.up * (1 - remainingJumpTime) * jumpForce * Time.deltaTime);
            yield return new WaitForEndOfFrame();
            remainingJumpTime -= Time.deltaTime;
        }
        jumping = false;
    }

    public Vector3 ApplyDisplacement(Vector3 displacement, bool checkCollision)
    {
        if (checkCollision)
        {
            CheckPlayerCollision(ref displacement);
        }

        xrPlayer.transform.position += displacement;
        return displacement;
    }

    private Vector3 GetJoyStickForward()
    {
        switch (forwardDisplacement)
        {
            case MovementType.CameraRotationBased:
                return xrPlayer.head.transform.forward * Time.deltaTime * horizontalDisplacementSpeed *
                       XRInputsManager.GetInstance().leftJoyStick_Y;
            case MovementType.CameraHorizontalBased:
                return Vector3.Normalize(Vector3.ProjectOnPlane(xrPlayer.head.transform.forward, Vector3.up)) *
                       Time.deltaTime * horizontalDisplacementSpeed * XRInputsManager.GetInstance().leftJoyStick_Y;
            case MovementType.PlayerBased:
                return xrPlayer.transform.forward * Time.deltaTime * horizontalDisplacementSpeed *
                       XRInputsManager.GetInstance().leftJoyStick_Y;
            case MovementType.WorldBased:
                return Vector3.forward * Time.deltaTime * horizontalDisplacementSpeed *
                       XRInputsManager.GetInstance().leftJoyStick_Y;
        }

        return Vector3.zero;
    }

    private Vector3 GetJoyStickLateral()
    {
        switch (lateralDisplacement)
        {
            case MovementType.CameraRotationBased:
                return xrPlayer.head.transform.right * Time.deltaTime * horizontalDisplacementSpeed *
                       XRInputsManager.GetInstance().leftJoyStick_X;
            case MovementType.CameraHorizontalBased:
                return Vector3.Normalize(Vector3.ProjectOnPlane(xrPlayer.head.transform.right, Vector3.up)) *
                       Time.deltaTime * horizontalDisplacementSpeed * XRInputsManager.GetInstance().leftJoyStick_X;
            case MovementType.PlayerBased:
                return xrPlayer.transform.right * Time.deltaTime * horizontalDisplacementSpeed *
                       XRInputsManager.GetInstance().leftJoyStick_X;
            case MovementType.WorldBased:
                return Vector3.right * Time.deltaTime * horizontalDisplacementSpeed *
                       XRInputsManager.GetInstance().leftJoyStick_X;
        }

        return Vector3.zero;
    }

    private Vector3 GetJoyStickVertical()
    {
        switch (verticalDisplacement)
        {
            case MovementType.CameraRotationBased:
                return xrPlayer.head.transform.up * Time.deltaTime * verticalDisplacementSpeed *
                       XRInputsManager.GetInstance().rightJoyStick_Y;
            case MovementType.PlayerBased:
                return xrPlayer.transform.up * Time.deltaTime * verticalDisplacementSpeed *
                       XRInputsManager.GetInstance().rightJoyStick_Y;
            case MovementType.CameraHorizontalBased:
            case MovementType.WorldBased:
                return Vector3.up * Time.deltaTime * verticalDisplacementSpeed *
                       XRInputsManager.GetInstance().rightJoyStick_Y;
        }

        return Vector3.zero;
    }

    public void CheckPlayerCollision(ref Vector3 displacement)
    {
        RaycastHit hit;
        Vector3 rayOrigin = xrPlayer.transform.position + Vector3.up * stepHeight;
#if UNITY_EDITOR
        Vector3 playerRadius = Vector3.Normalize(displacement) * playerRadiusLength;
        if (debugRays)
        {
            Debug.DrawRay(rayOrigin, displacement + playerRadius, Color.red, 0.2f);
        }
#endif
        if (Utils.RayCastIgnoring<XRPlayer>(rayOrigin, displacement, out hit,
                displacement.magnitude + playerRadiusLength, true))
        {
#if !UNITY_EDITOR
            Vector3 playerRadius = Vector3.Normalize(displacement) * playerRadiusLength;
#endif
            displacement = hit.point - rayOrigin - playerRadius;
        }
    }

    private void JoyStickRotation()
    {
        xrPlayer.transform.Rotate(
            new Vector3(0, Time.deltaTime * cameraRotationSpeed * XRInputsManager.GetInstance().rightJoyStick_X, 0),
            Space.World);
    }

    private void CheckFloorMovement()
    {
        if (floor && floor.position != lastFloorPosition)
        {
            ApplyDisplacement(floor.position - lastFloorPosition, true);
        }
    }

    private float fallingSpeed = 0;
    private float maxFallingSpeed = 55;

    private void CheckFall()
    {
        if (!jumping)
        {
            RaycastHit hit;
            Vector3 centeredHeadPosition = new Vector3(xrPlayer.transform.position.x, xrPlayer.head.transform.position.y,
                xrPlayer.transform.position.z);
#if UNITY_EDITOR
            if (debugRays)
            {
                Debug.DrawRay(centeredHeadPosition, Vector3.down, Color.red, 0.2f);
            }
#endif
            if (Utils.RayCastIgnoring<XRPlayer>(centeredHeadPosition, Vector3.down, out hit,
                    xrPlayer.head.transform.localPosition.y + fallingSpeed, true))
            {
                fallingSpeed = 0;
                landedJump = true;
                xrPlayer.transform.position =
                    new Vector3(xrPlayer.transform.position.x, hit.point.y, xrPlayer.transform.position.z);
                Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
                if (!rb || rb.isKinematic)
                {
                    floor = hit.transform;
                    lastFloorPosition = floor.transform.position;
                }
            }
            else
            {
                floor = null;
                xrPlayer.transform.position = new Vector3(xrPlayer.transform.position.x,
                    xrPlayer.transform.position.y - fallingSpeed, xrPlayer.transform.position.z);
                fallingSpeed += Time.deltaTime * Time.deltaTime * 9.8f;
#if UNITY_EDITOR
                if (recordSpeed && fallingSpeed > maxReachedSpeed)
                {
                    maxReachedSpeed = fallingSpeed;
                }
#endif
                if (fallingSpeed > maxFallingSpeed)
                {
                    fallingSpeed = maxFallingSpeed;
                }
            }
        }
    }

#if UNITY_EDITOR
    public bool recordSpeed = false;
    public float maxReachedSpeed = 0;
#endif

    private void Dive()
    {
        float handDistance =
            Vector3.Distance(xrPlayer.rightHand.transform.position, xrPlayer.leftHand.transform.position);
        if (lastMovement == MovementSystem.Diving)
        {
            Vector3 direction = Vector3.Normalize(xrPlayer.rightHand.transform.position +
                xrPlayer.leftHand.transform.position - 2 * xrPlayer.ChestGuess());
            float distanceDiference = handDistance - lastHandDistance;
            if (distanceDiference > 0)
            {
                xrPlayer.transform.position += direction * handDistance * distanceDiference * diveSpeed;
            }
        }

        lastHandDistance = handDistance;
    }

    private void FollowHead()
    {
        Vector3 displacement =
            Vector3.ProjectOnPlane(xrPlayer.head.transform.position - xrPlayer.transform.position, Vector3.up);
        displacement = ApplyDisplacement(displacement, true);
        xrPlayer.rigOffset.position -= displacement;
    }

    public enum MovementSystem
    {
        None,
        Walk,
        Flying,
        Diving,
        ArmSwing,
        Teleport
    }

    public enum MovementType
    {
        CameraHorizontalBased,
        CameraRotationBased,
        PlayerBased,
        WorldBased
    }
}
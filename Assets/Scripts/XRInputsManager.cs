using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class XRInputsManager : MonoBehaviour
{
    private XRInputs xrInputs;

    private static XRInputsManager instance;

#if UNITY_EDITOR
    public bool printInputs;
#endif

    private void Awake()
    {
        instance = this;
        xrInputs = new XRInputs();

        BindRightControllerEvents();
        BindLeftControllerEvents();

        xrInputs.Enable();
    }

    #region RightControllerEvents

    public UnityEvent OnRightTriggerPressed = new UnityEvent();
    public UnityEvent OnRightTriggerReleased = new UnityEvent();
    public UnityEvent OnRightGripPressed = new UnityEvent();
    public UnityEvent OnRightGripReleased = new UnityEvent();
    public UnityEvent OnRightPrimaryButtonPressed = new UnityEvent();
    public UnityEvent OnRightPrimaryButtonReleased = new UnityEvent();
    public UnityEvent OnRightSecondaryButtonPressed = new UnityEvent();
    public UnityEvent OnRightSecondaryButtonReleased = new UnityEvent();
    public UnityEvent OnRightJoyStickPressed = new UnityEvent();
    public UnityEvent OnRightJoyStickReleased = new UnityEvent();

    public bool holdingRightTrigger = false;
    public bool holdingRightGrip = false;
    public bool holdingRightPrimaryButton = false;
    public bool holdingRightSecondaryButton = false;
    public bool holdingRightJoyStick = false;

    private void BindRightControllerEvents()
    {
        xrInputs.RightController.Trigger.started += PressRightTrigger;
        xrInputs.RightController.Trigger.canceled += ReleaseRightTrigger;
        xrInputs.RightController.Grip.started += PressRightGrip;
        xrInputs.RightController.Grip.canceled += ReleaseRightGrip;
        xrInputs.RightController.ButtonAX.started += PressRightButtonAX;
        xrInputs.RightController.ButtonAX.canceled += ReleaseRightButtonAX;
        xrInputs.RightController.ButtonBY.started += PressRightButtonBY;
        xrInputs.RightController.ButtonBY.canceled += ReleaseRightButtonBY;
        xrInputs.RightController.JoyStickButton.started += PressRightJoystickButton;
        xrInputs.RightController.JoyStickButton.canceled += ReleaseRightJoystickButton;
    }

    private void PressRightTrigger(InputAction.CallbackContext obj)
    {
        OnRightTriggerPressed.Invoke();
        holdingRightTrigger = true;
#if UNITY_EDITOR
        if (printInputs)
        {
            print("RightTriggerPressed");
        }
#endif
    }

    private void ReleaseRightTrigger(InputAction.CallbackContext obj)
    {
        OnRightTriggerReleased.Invoke();
        holdingRightTrigger = false;
#if UNITY_EDITOR
        if (printInputs)
        {
            print("RightTriggerReleased");
        }
#endif
    }

    private void PressRightGrip(InputAction.CallbackContext obj)
    {
        OnRightGripPressed.Invoke();
        holdingRightGrip = true;
#if UNITY_EDITOR
        if (printInputs)
        {
            print("RightGripPressed");
        }
#endif
    }

    private void ReleaseRightGrip(InputAction.CallbackContext obj)
    {
        OnRightGripReleased.Invoke();
        holdingRightGrip = false;
#if UNITY_EDITOR
        if (printInputs)
        {
            print("RightGripReleased");
        }
#endif
    }

    private void PressRightButtonAX(InputAction.CallbackContext obj)
    {
        OnRightPrimaryButtonPressed.Invoke();
        holdingRightPrimaryButton = true;
#if UNITY_EDITOR
        if (printInputs)
        {
            print("RightPrimaryButtonPressed");
        }
#endif
    }

    private void ReleaseRightButtonAX(InputAction.CallbackContext obj)
    {
        OnRightPrimaryButtonReleased.Invoke();
        holdingRightPrimaryButton = false;
#if UNITY_EDITOR
        if (printInputs)
        {
            print("RightPrimaryButtonReleased");
        }
#endif
    }

    private void PressRightButtonBY(InputAction.CallbackContext obj)
    {
        OnRightSecondaryButtonPressed.Invoke();
        holdingRightSecondaryButton = true;
#if UNITY_EDITOR
        if (printInputs)
        {
            print("RightSecondaryButtonPressed");
        }
#endif
    }

    private void ReleaseRightButtonBY(InputAction.CallbackContext obj)
    {
        OnRightSecondaryButtonReleased.Invoke();
        holdingRightSecondaryButton = false;
#if UNITY_EDITOR
        if (printInputs)
        {
            print("RightSecondaryButtonReleased");
        }
#endif
    }

    private void PressRightJoystickButton(InputAction.CallbackContext obj)
    {
        OnRightJoyStickPressed.Invoke();
        holdingRightJoyStick = true;
#if UNITY_EDITOR
        if (printInputs)
        {
            print("RightJoyStickPressed");
        }
#endif
    }

    private void ReleaseRightJoystickButton(InputAction.CallbackContext obj)
    {
        OnRightJoyStickReleased.Invoke();
        holdingRightJoyStick = false;
#if UNITY_EDITOR
        if (printInputs)
        {
            print("RightJoyStickReleased");
        }
#endif
    }


    #endregion

    #region LeftControllerEvents

    public UnityEvent OnLeftTriggerPressed = new UnityEvent();
    public UnityEvent OnLeftTriggerReleased = new UnityEvent();
    public UnityEvent OnLeftGripPressed = new UnityEvent();
    public UnityEvent OnLeftGripReleased = new UnityEvent();
    public UnityEvent OnLeftPrimaryButtonPressed = new UnityEvent();
    public UnityEvent OnLeftPrimaryButtonReleased = new UnityEvent();
    public UnityEvent OnLeftSecondaryButtonPressed = new UnityEvent();
    public UnityEvent OnLeftSecondaryButtonReleased = new UnityEvent();
    public UnityEvent OnLeftJoyStickPressed = new UnityEvent();
    public UnityEvent OnLeftJoyStickReleased = new UnityEvent();

    public bool holdingLeftTrigger = false;
    public bool holdingLeftGrip = false;
    public bool holdingLeftPrimaryButton = false;
    public bool holdingLeftSecondaryButton = false;
    public bool holdingLeftJoyStick = false;

    private void BindLeftControllerEvents()
    {
        xrInputs.LeftController.Trigger.started += PressLeftTrigger;
        xrInputs.LeftController.Trigger.canceled += ReleaseLeftTrigger;
        xrInputs.LeftController.Grip.started += PressLeftGrip;
        xrInputs.LeftController.Grip.canceled += ReleaseLeftGrip;
        xrInputs.LeftController.ButtonAX.started += PressLeftButtonAX;
        xrInputs.LeftController.ButtonAX.canceled += ReleaseLeftButtonAX;
        xrInputs.LeftController.ButtonBY.started += PressLeftButtonBY;
        xrInputs.LeftController.ButtonBY.canceled += ReleaseLeftButtonBY;
        xrInputs.LeftController.JoyStickButton.started += PressLeftJoystickButton;
        xrInputs.LeftController.JoyStickButton.canceled += ReleaseLeftJoystickButton;
    }

    private void PressLeftTrigger(InputAction.CallbackContext obj)
    {
        OnLeftTriggerPressed.Invoke();
        holdingLeftTrigger = true;
#if UNITY_EDITOR
        if (printInputs)
        {
            print("LeftTriggerPressed");
        }
#endif
    }

    private void ReleaseLeftTrigger(InputAction.CallbackContext obj)
    {
        OnLeftTriggerReleased.Invoke();
        holdingLeftTrigger = false;
#if UNITY_EDITOR
        if (printInputs)
        {
            print("LeftTriggerReleased");
        }
#endif
    }

    private void PressLeftGrip(InputAction.CallbackContext obj)
    {
        OnLeftGripPressed.Invoke();
        holdingLeftGrip = true;
#if UNITY_EDITOR
        if (printInputs)
        {
            print("LeftGripPressed");
        }
#endif
    }

    private void ReleaseLeftGrip(InputAction.CallbackContext obj)
    {
        OnLeftGripReleased.Invoke();
        holdingLeftGrip = false;
#if UNITY_EDITOR
        if (printInputs)
        {
            print("LeftGripReleased");
        }
#endif
    }

    private void PressLeftButtonAX(InputAction.CallbackContext obj)
    {
        OnLeftPrimaryButtonPressed.Invoke();
        holdingLeftPrimaryButton = true;
#if UNITY_EDITOR
        if (printInputs)
        {
            print("LeftPrimaryButtonPressed");
        }
#endif
    }

    private void ReleaseLeftButtonAX(InputAction.CallbackContext obj)
    {
        OnLeftPrimaryButtonReleased.Invoke();
        holdingLeftPrimaryButton = false;
#if UNITY_EDITOR
        if (printInputs)
        {
            print("LeftPrimaryButtonReleased");
        }
#endif
    }

    private void PressLeftButtonBY(InputAction.CallbackContext obj)
    {
        OnLeftSecondaryButtonPressed.Invoke();
        holdingLeftSecondaryButton = true;
#if UNITY_EDITOR
        if (printInputs)
        {
            print("LeftSecondaryButtonPressed");
        }
#endif
    }

    private void ReleaseLeftButtonBY(InputAction.CallbackContext obj)
    {
        OnLeftSecondaryButtonReleased.Invoke();
        holdingLeftSecondaryButton = false;
#if UNITY_EDITOR
        if (printInputs)
        {
            print("LeftSecondaryButtonReleased");
        }
#endif
    }

    private void PressLeftJoystickButton(InputAction.CallbackContext obj)
    {
        OnLeftJoyStickPressed.Invoke();
        holdingLeftJoyStick = true;
#if UNITY_EDITOR
        if (printInputs)
        {
            print("LeftJoyStickPressed");
        }
#endif
    }

    private void ReleaseLeftJoystickButton(InputAction.CallbackContext obj)
    {
        OnLeftJoyStickReleased.Invoke();
        holdingLeftJoyStick = false;
#if UNITY_EDITOR
        if (printInputs)
        {
            print("LeftJoyStickReleased");
        }
#endif
    }

    #endregion

    public float rightJoyStick_X;
    public float rightJoyStick_Y;
    public float leftJoyStick_X;
    public float leftJoyStick_Y;

    private void Update()
    {
        rightJoyStick_X = xrInputs.RightController.JoyStickX.ReadValue<float>();
        rightJoyStick_Y = xrInputs.RightController.JoyStickY.ReadValue<float>();
        leftJoyStick_X = xrInputs.LeftController.JoyStickX.ReadValue<float>();
        leftJoyStick_Y = xrInputs.LeftController.JoyStickY.ReadValue<float>();
    }

    public static XRInputsManager GetInstance()
    {
        if (!instance)
        {
            instance = new XRInputsManager();
        }
        return instance;
    }
}

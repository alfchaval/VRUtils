// GENERATED AUTOMATICALLY FROM 'Assets/XR/XRInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @XRInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @XRInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""XRInputs"",
    ""maps"": [
        {
            ""name"": ""RightController"",
            ""id"": ""07fad600-4d41-4d5a-b93c-b3672b7af2a9"",
            ""actions"": [
                {
                    ""name"": ""Trigger"",
                    ""type"": ""Button"",
                    ""id"": ""892252de-0305-476d-9e81-0ccbb4d3ad06"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grip"",
                    ""type"": ""Button"",
                    ""id"": ""914f8d7f-c782-4c0a-b014-baf3a4a55200"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonAX"",
                    ""type"": ""Button"",
                    ""id"": ""b099fcdc-a039-4179-85d7-664f12c581ed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonBY"",
                    ""type"": ""Button"",
                    ""id"": ""5751d237-2dda-49f6-b1aa-1bcc288a7a72"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JoyStickButton"",
                    ""type"": ""Button"",
                    ""id"": ""6611656b-0b2c-47f6-8b97-0192dbdd5c0e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JoyStickX"",
                    ""type"": ""Value"",
                    ""id"": ""321526a8-4345-4031-960f-eff2964681f0"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JoyStickY"",
                    ""type"": ""Value"",
                    ""id"": ""85d6dfbf-8357-4114-a822-73aeb4adbda8"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""39dd3a4d-fb3a-4596-94ae-5acb5ca00a51"",
                    ""path"": ""<XRController>{RightHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""483eb3b3-bdc2-4a0b-ba25-d2d41ae7954a"",
                    ""path"": ""<ValveIndexController>{RightHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cdca4535-ffec-48de-bddc-e1b3487e9025"",
                    ""path"": ""<OculusTouchController>{RightHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ec91673c-6a36-4fa4-8e07-d7ea8b3b7f58"",
                    ""path"": ""<ViveController>{RightHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""025fed7e-4b8a-4994-b755-e9d6f7dca5b4"",
                    ""path"": ""<ValveIndexController>{RightHand}/thumbstick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoyStickX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2aaf3836-c0f3-4012-992c-1f6a27854bc7"",
                    ""path"": ""<OculusTouchController>{RightHand}/thumbstick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoyStickX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""784000cb-de89-4a11-b6ce-4ee0e41e7829"",
                    ""path"": ""<ViveController>{RightHand}/trackpad/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoyStickX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1042eb58-3ebe-4047-adb6-0c318af80d01"",
                    ""path"": ""<ValveIndexController>{RightHand}/thumbstick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoyStickY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6cf1932-fcf8-487e-b78d-cf563bad65d8"",
                    ""path"": ""<OculusTouchController>{RightHand}/thumbstick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoyStickY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc05809f-05c0-4e6d-babb-9e545021b521"",
                    ""path"": ""<ViveController>{RightHand}/trackpad/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoyStickY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed486969-6465-4b10-80fa-e2a54f15599c"",
                    ""path"": ""<XRController>{RightHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a20dc499-1afd-438a-ba19-475150f7bfdf"",
                    ""path"": ""<ValveIndexController>{RightHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67df4312-12f9-4046-9af7-157d191895c0"",
                    ""path"": ""<OculusTouchController>{RightHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b845e682-cc6c-4a86-abb4-71c83411cf73"",
                    ""path"": ""<ViveController>{RightHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f117d928-9ba9-4830-9f47-70b530a7c721"",
                    ""path"": ""<XRController>{RightHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonAX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89bec254-0477-49cf-91de-3dcab1b945a3"",
                    ""path"": ""<ValveIndexController>{RightHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonAX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4dcd4d0a-339b-4ef4-8911-983e8ca55771"",
                    ""path"": ""<OculusTouchController>{RightHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonAX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""83a6c7da-eef1-4422-9b44-3188a51b3e0a"",
                    ""path"": ""<XRController>{RightHand}/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonBY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba53dbea-619d-4595-988f-a93e5324b290"",
                    ""path"": ""<ValveIndexController>{RightHand}/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonBY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b566005-4bc6-44c8-af4f-56b5f1f56ffc"",
                    ""path"": ""<OculusTouchController>{RightHand}/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonBY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8ac8750-4738-444c-83ab-6e129ee94d90"",
                    ""path"": ""<XRController>{RightHand}/joystickClicked"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoyStickButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04e99b40-1782-44fc-a7c7-2782a6124fe7"",
                    ""path"": ""<ValveIndexController>{RightHand}/thumbstickClicked"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoyStickButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75f44297-3c6e-479d-bfde-c7df37aa33b9"",
                    ""path"": ""<OculusTouchController>{RightHand}/thumbstickClicked"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoyStickButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4f7700f-693a-40c2-8fc8-9f42836351a0"",
                    ""path"": ""<ViveController>{RightHand}/trackpadClicked"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoyStickButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""LeftController"",
            ""id"": ""ca240484-9a5e-4fbc-9932-06950f2c29fa"",
            ""actions"": [
                {
                    ""name"": ""Trigger"",
                    ""type"": ""Button"",
                    ""id"": ""806e8700-86ba-4991-9642-2c6c5bc1a6b0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grip"",
                    ""type"": ""Button"",
                    ""id"": ""d94d7a82-6177-4564-8857-571eb06760be"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonAX"",
                    ""type"": ""Button"",
                    ""id"": ""b4ab1be4-c7bc-4527-b29c-039df80cc88e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonBY"",
                    ""type"": ""Button"",
                    ""id"": ""89fa6985-ca8d-4b91-98b5-45d40eb8a287"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JoyStickButton"",
                    ""type"": ""Button"",
                    ""id"": ""4baf730f-820c-44b1-9553-48379b2c04ff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JoyStickX"",
                    ""type"": ""Value"",
                    ""id"": ""301f2e5e-39b7-44cb-9f14-3a2bd77e7b9f"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JoyStickY"",
                    ""type"": ""Value"",
                    ""id"": ""fe97c258-5950-4e80-857b-6928c30c3b12"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f03c076e-0818-4d4a-acff-c18971d9b8b2"",
                    ""path"": ""<XRController>{LeftHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""83200cd7-efaa-4d8e-b0f1-e80bfd04a202"",
                    ""path"": ""<ValveIndexController>{LeftHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""726042d7-255c-401a-96bd-2a1351cee5cd"",
                    ""path"": ""<OculusTouchController>{LeftHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d9ef1fa-d40e-4e64-8f04-029ec33bd4c3"",
                    ""path"": ""<ViveController>{LeftHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4fd8080d-7247-4285-a2ca-70ddccf514a6"",
                    ""path"": ""<XRController>{LeftHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8513fc0d-95cb-4b20-a395-f8fea58200c5"",
                    ""path"": ""<ValveIndexController>{LeftHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""26f69e00-388f-4cbf-9eaf-44d037822886"",
                    ""path"": ""<OculusTouchController>{LeftHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""54f61db7-e349-45de-ac83-98d1e40e5fd8"",
                    ""path"": ""<ViveController>{LeftHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""42a01d80-b864-40a0-87e2-7321847c71ec"",
                    ""path"": ""<XRController>{LeftHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonAX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9d609f1-4288-4f09-8a9c-51fa39b46d87"",
                    ""path"": ""<ValveIndexController>{LeftHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonAX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bdde2db6-cb6d-49d1-ad58-442791a74970"",
                    ""path"": ""<OculusTouchController>{LeftHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonAX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e2da894-897d-4255-ac4a-2c88bd43128b"",
                    ""path"": ""<XRController>{LeftHand}/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonBY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a43a00a-7ce2-4d59-bcd6-423e8fa122f1"",
                    ""path"": ""<ValveIndexController>{LeftHand}/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonBY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7bfb12b-6306-44c5-bc89-d8ec0385e817"",
                    ""path"": ""<OculusTouchController>{LeftHand}/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonBY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80bcd06f-bde5-4311-897c-bb334c0351ab"",
                    ""path"": ""<XRController>{LeftHand}/joystickClicked"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoyStickButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""481209a3-d5a3-4140-8a8e-97fc1039b6a1"",
                    ""path"": ""<ValveIndexController>{LeftHand}/thumbstickClicked"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoyStickButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e1d4369-1e51-44b1-a12e-f9139d55e352"",
                    ""path"": ""<OculusTouchController>{LeftHand}/thumbstickClicked"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoyStickButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d3f4f8e8-e9d4-4694-ad93-c0178a6546ac"",
                    ""path"": ""<ViveController>{LeftHand}/trackpadClicked"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoyStickButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b49720c6-c580-4c6c-97d5-c5b1906a1c15"",
                    ""path"": ""<ValveIndexController>{LeftHand}/thumbstick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoyStickX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90ea540f-0e58-45a0-9df7-3fda13c58640"",
                    ""path"": ""<OculusTouchController>/thumbstick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoyStickX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b081cd54-aa78-467b-9fe5-c0918891a4d9"",
                    ""path"": ""<ViveController>{LeftHand}/trackpad/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoyStickX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1a3e21f-1899-4cf5-bd20-8b62451794ef"",
                    ""path"": ""<ValveIndexController>{LeftHand}/thumbstick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoyStickY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71766693-3ee4-4ce6-8a7f-cd68868c6d04"",
                    ""path"": ""<OculusTouchController>/thumbstick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoyStickY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08a47163-5fc8-4cae-a024-e3c862d6d0b7"",
                    ""path"": ""<ViveController>{LeftHand}/trackpad/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoyStickY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // RightController
        m_RightController = asset.FindActionMap("RightController", throwIfNotFound: true);
        m_RightController_Trigger = m_RightController.FindAction("Trigger", throwIfNotFound: true);
        m_RightController_Grip = m_RightController.FindAction("Grip", throwIfNotFound: true);
        m_RightController_ButtonAX = m_RightController.FindAction("ButtonAX", throwIfNotFound: true);
        m_RightController_ButtonBY = m_RightController.FindAction("ButtonBY", throwIfNotFound: true);
        m_RightController_JoyStickButton = m_RightController.FindAction("JoyStickButton", throwIfNotFound: true);
        m_RightController_JoyStickX = m_RightController.FindAction("JoyStickX", throwIfNotFound: true);
        m_RightController_JoyStickY = m_RightController.FindAction("JoyStickY", throwIfNotFound: true);
        // LeftController
        m_LeftController = asset.FindActionMap("LeftController", throwIfNotFound: true);
        m_LeftController_Trigger = m_LeftController.FindAction("Trigger", throwIfNotFound: true);
        m_LeftController_Grip = m_LeftController.FindAction("Grip", throwIfNotFound: true);
        m_LeftController_ButtonAX = m_LeftController.FindAction("ButtonAX", throwIfNotFound: true);
        m_LeftController_ButtonBY = m_LeftController.FindAction("ButtonBY", throwIfNotFound: true);
        m_LeftController_JoyStickButton = m_LeftController.FindAction("JoyStickButton", throwIfNotFound: true);
        m_LeftController_JoyStickX = m_LeftController.FindAction("JoyStickX", throwIfNotFound: true);
        m_LeftController_JoyStickY = m_LeftController.FindAction("JoyStickY", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // RightController
    private readonly InputActionMap m_RightController;
    private IRightControllerActions m_RightControllerActionsCallbackInterface;
    private readonly InputAction m_RightController_Trigger;
    private readonly InputAction m_RightController_Grip;
    private readonly InputAction m_RightController_ButtonAX;
    private readonly InputAction m_RightController_ButtonBY;
    private readonly InputAction m_RightController_JoyStickButton;
    private readonly InputAction m_RightController_JoyStickX;
    private readonly InputAction m_RightController_JoyStickY;
    public struct RightControllerActions
    {
        private @XRInputs m_Wrapper;
        public RightControllerActions(@XRInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Trigger => m_Wrapper.m_RightController_Trigger;
        public InputAction @Grip => m_Wrapper.m_RightController_Grip;
        public InputAction @ButtonAX => m_Wrapper.m_RightController_ButtonAX;
        public InputAction @ButtonBY => m_Wrapper.m_RightController_ButtonBY;
        public InputAction @JoyStickButton => m_Wrapper.m_RightController_JoyStickButton;
        public InputAction @JoyStickX => m_Wrapper.m_RightController_JoyStickX;
        public InputAction @JoyStickY => m_Wrapper.m_RightController_JoyStickY;
        public InputActionMap Get() { return m_Wrapper.m_RightController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RightControllerActions set) { return set.Get(); }
        public void SetCallbacks(IRightControllerActions instance)
        {
            if (m_Wrapper.m_RightControllerActionsCallbackInterface != null)
            {
                @Trigger.started -= m_Wrapper.m_RightControllerActionsCallbackInterface.OnTrigger;
                @Trigger.performed -= m_Wrapper.m_RightControllerActionsCallbackInterface.OnTrigger;
                @Trigger.canceled -= m_Wrapper.m_RightControllerActionsCallbackInterface.OnTrigger;
                @Grip.started -= m_Wrapper.m_RightControllerActionsCallbackInterface.OnGrip;
                @Grip.performed -= m_Wrapper.m_RightControllerActionsCallbackInterface.OnGrip;
                @Grip.canceled -= m_Wrapper.m_RightControllerActionsCallbackInterface.OnGrip;
                @ButtonAX.started -= m_Wrapper.m_RightControllerActionsCallbackInterface.OnButtonAX;
                @ButtonAX.performed -= m_Wrapper.m_RightControllerActionsCallbackInterface.OnButtonAX;
                @ButtonAX.canceled -= m_Wrapper.m_RightControllerActionsCallbackInterface.OnButtonAX;
                @ButtonBY.started -= m_Wrapper.m_RightControllerActionsCallbackInterface.OnButtonBY;
                @ButtonBY.performed -= m_Wrapper.m_RightControllerActionsCallbackInterface.OnButtonBY;
                @ButtonBY.canceled -= m_Wrapper.m_RightControllerActionsCallbackInterface.OnButtonBY;
                @JoyStickButton.started -= m_Wrapper.m_RightControllerActionsCallbackInterface.OnJoyStickButton;
                @JoyStickButton.performed -= m_Wrapper.m_RightControllerActionsCallbackInterface.OnJoyStickButton;
                @JoyStickButton.canceled -= m_Wrapper.m_RightControllerActionsCallbackInterface.OnJoyStickButton;
                @JoyStickX.started -= m_Wrapper.m_RightControllerActionsCallbackInterface.OnJoyStickX;
                @JoyStickX.performed -= m_Wrapper.m_RightControllerActionsCallbackInterface.OnJoyStickX;
                @JoyStickX.canceled -= m_Wrapper.m_RightControllerActionsCallbackInterface.OnJoyStickX;
                @JoyStickY.started -= m_Wrapper.m_RightControllerActionsCallbackInterface.OnJoyStickY;
                @JoyStickY.performed -= m_Wrapper.m_RightControllerActionsCallbackInterface.OnJoyStickY;
                @JoyStickY.canceled -= m_Wrapper.m_RightControllerActionsCallbackInterface.OnJoyStickY;
            }
            m_Wrapper.m_RightControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Trigger.started += instance.OnTrigger;
                @Trigger.performed += instance.OnTrigger;
                @Trigger.canceled += instance.OnTrigger;
                @Grip.started += instance.OnGrip;
                @Grip.performed += instance.OnGrip;
                @Grip.canceled += instance.OnGrip;
                @ButtonAX.started += instance.OnButtonAX;
                @ButtonAX.performed += instance.OnButtonAX;
                @ButtonAX.canceled += instance.OnButtonAX;
                @ButtonBY.started += instance.OnButtonBY;
                @ButtonBY.performed += instance.OnButtonBY;
                @ButtonBY.canceled += instance.OnButtonBY;
                @JoyStickButton.started += instance.OnJoyStickButton;
                @JoyStickButton.performed += instance.OnJoyStickButton;
                @JoyStickButton.canceled += instance.OnJoyStickButton;
                @JoyStickX.started += instance.OnJoyStickX;
                @JoyStickX.performed += instance.OnJoyStickX;
                @JoyStickX.canceled += instance.OnJoyStickX;
                @JoyStickY.started += instance.OnJoyStickY;
                @JoyStickY.performed += instance.OnJoyStickY;
                @JoyStickY.canceled += instance.OnJoyStickY;
            }
        }
    }
    public RightControllerActions @RightController => new RightControllerActions(this);

    // LeftController
    private readonly InputActionMap m_LeftController;
    private ILeftControllerActions m_LeftControllerActionsCallbackInterface;
    private readonly InputAction m_LeftController_Trigger;
    private readonly InputAction m_LeftController_Grip;
    private readonly InputAction m_LeftController_ButtonAX;
    private readonly InputAction m_LeftController_ButtonBY;
    private readonly InputAction m_LeftController_JoyStickButton;
    private readonly InputAction m_LeftController_JoyStickX;
    private readonly InputAction m_LeftController_JoyStickY;
    public struct LeftControllerActions
    {
        private @XRInputs m_Wrapper;
        public LeftControllerActions(@XRInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Trigger => m_Wrapper.m_LeftController_Trigger;
        public InputAction @Grip => m_Wrapper.m_LeftController_Grip;
        public InputAction @ButtonAX => m_Wrapper.m_LeftController_ButtonAX;
        public InputAction @ButtonBY => m_Wrapper.m_LeftController_ButtonBY;
        public InputAction @JoyStickButton => m_Wrapper.m_LeftController_JoyStickButton;
        public InputAction @JoyStickX => m_Wrapper.m_LeftController_JoyStickX;
        public InputAction @JoyStickY => m_Wrapper.m_LeftController_JoyStickY;
        public InputActionMap Get() { return m_Wrapper.m_LeftController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LeftControllerActions set) { return set.Get(); }
        public void SetCallbacks(ILeftControllerActions instance)
        {
            if (m_Wrapper.m_LeftControllerActionsCallbackInterface != null)
            {
                @Trigger.started -= m_Wrapper.m_LeftControllerActionsCallbackInterface.OnTrigger;
                @Trigger.performed -= m_Wrapper.m_LeftControllerActionsCallbackInterface.OnTrigger;
                @Trigger.canceled -= m_Wrapper.m_LeftControllerActionsCallbackInterface.OnTrigger;
                @Grip.started -= m_Wrapper.m_LeftControllerActionsCallbackInterface.OnGrip;
                @Grip.performed -= m_Wrapper.m_LeftControllerActionsCallbackInterface.OnGrip;
                @Grip.canceled -= m_Wrapper.m_LeftControllerActionsCallbackInterface.OnGrip;
                @ButtonAX.started -= m_Wrapper.m_LeftControllerActionsCallbackInterface.OnButtonAX;
                @ButtonAX.performed -= m_Wrapper.m_LeftControllerActionsCallbackInterface.OnButtonAX;
                @ButtonAX.canceled -= m_Wrapper.m_LeftControllerActionsCallbackInterface.OnButtonAX;
                @ButtonBY.started -= m_Wrapper.m_LeftControllerActionsCallbackInterface.OnButtonBY;
                @ButtonBY.performed -= m_Wrapper.m_LeftControllerActionsCallbackInterface.OnButtonBY;
                @ButtonBY.canceled -= m_Wrapper.m_LeftControllerActionsCallbackInterface.OnButtonBY;
                @JoyStickButton.started -= m_Wrapper.m_LeftControllerActionsCallbackInterface.OnJoyStickButton;
                @JoyStickButton.performed -= m_Wrapper.m_LeftControllerActionsCallbackInterface.OnJoyStickButton;
                @JoyStickButton.canceled -= m_Wrapper.m_LeftControllerActionsCallbackInterface.OnJoyStickButton;
                @JoyStickX.started -= m_Wrapper.m_LeftControllerActionsCallbackInterface.OnJoyStickX;
                @JoyStickX.performed -= m_Wrapper.m_LeftControllerActionsCallbackInterface.OnJoyStickX;
                @JoyStickX.canceled -= m_Wrapper.m_LeftControllerActionsCallbackInterface.OnJoyStickX;
                @JoyStickY.started -= m_Wrapper.m_LeftControllerActionsCallbackInterface.OnJoyStickY;
                @JoyStickY.performed -= m_Wrapper.m_LeftControllerActionsCallbackInterface.OnJoyStickY;
                @JoyStickY.canceled -= m_Wrapper.m_LeftControllerActionsCallbackInterface.OnJoyStickY;
            }
            m_Wrapper.m_LeftControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Trigger.started += instance.OnTrigger;
                @Trigger.performed += instance.OnTrigger;
                @Trigger.canceled += instance.OnTrigger;
                @Grip.started += instance.OnGrip;
                @Grip.performed += instance.OnGrip;
                @Grip.canceled += instance.OnGrip;
                @ButtonAX.started += instance.OnButtonAX;
                @ButtonAX.performed += instance.OnButtonAX;
                @ButtonAX.canceled += instance.OnButtonAX;
                @ButtonBY.started += instance.OnButtonBY;
                @ButtonBY.performed += instance.OnButtonBY;
                @ButtonBY.canceled += instance.OnButtonBY;
                @JoyStickButton.started += instance.OnJoyStickButton;
                @JoyStickButton.performed += instance.OnJoyStickButton;
                @JoyStickButton.canceled += instance.OnJoyStickButton;
                @JoyStickX.started += instance.OnJoyStickX;
                @JoyStickX.performed += instance.OnJoyStickX;
                @JoyStickX.canceled += instance.OnJoyStickX;
                @JoyStickY.started += instance.OnJoyStickY;
                @JoyStickY.performed += instance.OnJoyStickY;
                @JoyStickY.canceled += instance.OnJoyStickY;
            }
        }
    }
    public LeftControllerActions @LeftController => new LeftControllerActions(this);
    public interface IRightControllerActions
    {
        void OnTrigger(InputAction.CallbackContext context);
        void OnGrip(InputAction.CallbackContext context);
        void OnButtonAX(InputAction.CallbackContext context);
        void OnButtonBY(InputAction.CallbackContext context);
        void OnJoyStickButton(InputAction.CallbackContext context);
        void OnJoyStickX(InputAction.CallbackContext context);
        void OnJoyStickY(InputAction.CallbackContext context);
    }
    public interface ILeftControllerActions
    {
        void OnTrigger(InputAction.CallbackContext context);
        void OnGrip(InputAction.CallbackContext context);
        void OnButtonAX(InputAction.CallbackContext context);
        void OnButtonBY(InputAction.CallbackContext context);
        void OnJoyStickButton(InputAction.CallbackContext context);
        void OnJoyStickX(InputAction.CallbackContext context);
        void OnJoyStickY(InputAction.CallbackContext context);
    }
}

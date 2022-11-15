//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Input Actions/GamePadControl.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @GamePadControl : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GamePadControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GamePadControl"",
    ""maps"": [
        {
            ""name"": ""Gamepad Controller"",
            ""id"": ""aa328d4f-4c30-47cd-9d00-a63278905dbd"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""1639c334-2738-4c7c-b11c-0c3efff80476"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""77caff32-02fa-4e51-95ac-fba14ea5ee64"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""e09fa913-f17b-47f6-90c7-79af0a9b4eb1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d60d7ac4-e291-4cfe-9d8e-36908741b382"",
                    ""path"": ""<XInputController>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3aff5898-fbb9-4ee6-bfd2-506ada8dfa89"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36706427-2a73-4206-b51c-d5cbc7afed04"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gamepad Controller
        m_GamepadController = asset.FindActionMap("Gamepad Controller", throwIfNotFound: true);
        m_GamepadController_Move = m_GamepadController.FindAction("Move", throwIfNotFound: true);
        m_GamepadController_Jump = m_GamepadController.FindAction("Jump", throwIfNotFound: true);
        m_GamepadController_Attack = m_GamepadController.FindAction("Attack", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Gamepad Controller
    private readonly InputActionMap m_GamepadController;
    private IGamepadControllerActions m_GamepadControllerActionsCallbackInterface;
    private readonly InputAction m_GamepadController_Move;
    private readonly InputAction m_GamepadController_Jump;
    private readonly InputAction m_GamepadController_Attack;
    public struct GamepadControllerActions
    {
        private @GamePadControl m_Wrapper;
        public GamepadControllerActions(@GamePadControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_GamepadController_Move;
        public InputAction @Jump => m_Wrapper.m_GamepadController_Jump;
        public InputAction @Attack => m_Wrapper.m_GamepadController_Attack;
        public InputActionMap Get() { return m_Wrapper.m_GamepadController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamepadControllerActions set) { return set.Get(); }
        public void SetCallbacks(IGamepadControllerActions instance)
        {
            if (m_Wrapper.m_GamepadControllerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnJump;
                @Attack.started -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnAttack;
            }
            m_Wrapper.m_GamepadControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
            }
        }
    }
    public GamepadControllerActions @GamepadController => new GamepadControllerActions(this);
    public interface IGamepadControllerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
    }
}

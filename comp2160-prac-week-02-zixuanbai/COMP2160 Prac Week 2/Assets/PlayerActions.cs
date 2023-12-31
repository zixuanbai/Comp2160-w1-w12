//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/PlayerActions.inputactions
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

public partial class @PlayerActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""driving"",
            ""id"": ""4915ec6b-7984-4e02-9c91-c3b2202146ad"",
            ""actions"": [
                {
                    ""name"": ""movement"",
                    ""type"": ""Value"",
                    ""id"": ""61dfc6d5-50d1-4cdb-b081-5352ffee8ab2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""turbo"",
                    ""type"": ""Button"",
                    ""id"": ""a46e00d7-d1c8-40bd-9507-720b7876fadf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""b4032f80-6d26-4f45-9457-ebcb9f11169f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0b170afb-5044-48c6-a091-d94701a38abb"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a089e539-2d62-4272-8550-3ad08e997176"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0fd00ab9-49e6-4443-bc05-2df1a64ca05e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f7fa9e48-8c28-4eff-bd2a-b6e6ba36c0c8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e663dabb-8949-43f0-87e4-d9f19a4f8aab"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""turbo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // driving
        m_driving = asset.FindActionMap("driving", throwIfNotFound: true);
        m_driving_movement = m_driving.FindAction("movement", throwIfNotFound: true);
        m_driving_turbo = m_driving.FindAction("turbo", throwIfNotFound: true);
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

    // driving
    private readonly InputActionMap m_driving;
    private IDrivingActions m_DrivingActionsCallbackInterface;
    private readonly InputAction m_driving_movement;
    private readonly InputAction m_driving_turbo;
    public struct DrivingActions
    {
        private @PlayerActions m_Wrapper;
        public DrivingActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @movement => m_Wrapper.m_driving_movement;
        public InputAction @turbo => m_Wrapper.m_driving_turbo;
        public InputActionMap Get() { return m_Wrapper.m_driving; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DrivingActions set) { return set.Get(); }
        public void SetCallbacks(IDrivingActions instance)
        {
            if (m_Wrapper.m_DrivingActionsCallbackInterface != null)
            {
                @movement.started -= m_Wrapper.m_DrivingActionsCallbackInterface.OnMovement;
                @movement.performed -= m_Wrapper.m_DrivingActionsCallbackInterface.OnMovement;
                @movement.canceled -= m_Wrapper.m_DrivingActionsCallbackInterface.OnMovement;
                @turbo.started -= m_Wrapper.m_DrivingActionsCallbackInterface.OnTurbo;
                @turbo.performed -= m_Wrapper.m_DrivingActionsCallbackInterface.OnTurbo;
                @turbo.canceled -= m_Wrapper.m_DrivingActionsCallbackInterface.OnTurbo;
            }
            m_Wrapper.m_DrivingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @movement.started += instance.OnMovement;
                @movement.performed += instance.OnMovement;
                @movement.canceled += instance.OnMovement;
                @turbo.started += instance.OnTurbo;
                @turbo.performed += instance.OnTurbo;
                @turbo.canceled += instance.OnTurbo;
            }
        }
    }
    public DrivingActions @driving => new DrivingActions(this);
    public interface IDrivingActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnTurbo(InputAction.CallbackContext context);
    }
}

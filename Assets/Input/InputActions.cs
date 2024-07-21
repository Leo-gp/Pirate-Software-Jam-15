//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Input/InputActions.inputactions
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

public partial class @InputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""fb5c029e-d15b-42f5-8354-a6a4f6292cbe"",
            ""actions"": [
                {
                    ""name"": ""Add Blue Ingredient"",
                    ""type"": ""Button"",
                    ""id"": ""aaf2bfd2-c46e-492d-ac2c-d8097f338cd8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Add Yellow Ingredient"",
                    ""type"": ""Button"",
                    ""id"": ""0708ffbb-f3dc-4a2e-82a1-9c237a879517"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Add Red Ingredient"",
                    ""type"": ""Button"",
                    ""id"": ""23542c0f-37ad-4571-8da0-ea984c2eaf98"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Launch Mixture"",
                    ""type"": ""Button"",
                    ""id"": ""8b5c0253-0a67-4827-b4cc-da8787010f0b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""98650157-40b4-4250-9f7b-640130e88c96"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Add Blue Ingredient"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e65268e6-784e-4ff1-b4df-d70708634fd5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Add Blue Ingredient"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00b340cf-8ad3-4811-93be-c859f555db4c"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Add Yellow Ingredient"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""139d8f83-3a71-45fc-9d82-144326a5a233"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Add Yellow Ingredient"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""02c76bd6-69be-4568-a11b-9e3d4cb21c13"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Add Red Ingredient"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""086da9c8-d486-4f46-ad75-d153beb1ae3c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Add Red Ingredient"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f016e029-2220-40b6-8de8-36ee62b942eb"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Launch Mixture"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_AddBlueIngredient = m_Player.FindAction("Add Blue Ingredient", throwIfNotFound: true);
        m_Player_AddYellowIngredient = m_Player.FindAction("Add Yellow Ingredient", throwIfNotFound: true);
        m_Player_AddRedIngredient = m_Player.FindAction("Add Red Ingredient", throwIfNotFound: true);
        m_Player_LaunchMixture = m_Player.FindAction("Launch Mixture", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_AddBlueIngredient;
    private readonly InputAction m_Player_AddYellowIngredient;
    private readonly InputAction m_Player_AddRedIngredient;
    private readonly InputAction m_Player_LaunchMixture;
    public struct PlayerActions
    {
        private @InputActions m_Wrapper;
        public PlayerActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @AddBlueIngredient => m_Wrapper.m_Player_AddBlueIngredient;
        public InputAction @AddYellowIngredient => m_Wrapper.m_Player_AddYellowIngredient;
        public InputAction @AddRedIngredient => m_Wrapper.m_Player_AddRedIngredient;
        public InputAction @LaunchMixture => m_Wrapper.m_Player_LaunchMixture;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @AddBlueIngredient.started += instance.OnAddBlueIngredient;
            @AddBlueIngredient.performed += instance.OnAddBlueIngredient;
            @AddBlueIngredient.canceled += instance.OnAddBlueIngredient;
            @AddYellowIngredient.started += instance.OnAddYellowIngredient;
            @AddYellowIngredient.performed += instance.OnAddYellowIngredient;
            @AddYellowIngredient.canceled += instance.OnAddYellowIngredient;
            @AddRedIngredient.started += instance.OnAddRedIngredient;
            @AddRedIngredient.performed += instance.OnAddRedIngredient;
            @AddRedIngredient.canceled += instance.OnAddRedIngredient;
            @LaunchMixture.started += instance.OnLaunchMixture;
            @LaunchMixture.performed += instance.OnLaunchMixture;
            @LaunchMixture.canceled += instance.OnLaunchMixture;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @AddBlueIngredient.started -= instance.OnAddBlueIngredient;
            @AddBlueIngredient.performed -= instance.OnAddBlueIngredient;
            @AddBlueIngredient.canceled -= instance.OnAddBlueIngredient;
            @AddYellowIngredient.started -= instance.OnAddYellowIngredient;
            @AddYellowIngredient.performed -= instance.OnAddYellowIngredient;
            @AddYellowIngredient.canceled -= instance.OnAddYellowIngredient;
            @AddRedIngredient.started -= instance.OnAddRedIngredient;
            @AddRedIngredient.performed -= instance.OnAddRedIngredient;
            @AddRedIngredient.canceled -= instance.OnAddRedIngredient;
            @LaunchMixture.started -= instance.OnLaunchMixture;
            @LaunchMixture.performed -= instance.OnLaunchMixture;
            @LaunchMixture.canceled -= instance.OnLaunchMixture;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnAddBlueIngredient(InputAction.CallbackContext context);
        void OnAddYellowIngredient(InputAction.CallbackContext context);
        void OnAddRedIngredient(InputAction.CallbackContext context);
        void OnLaunchMixture(InputAction.CallbackContext context);
    }
}

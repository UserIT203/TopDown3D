//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Input/ShopInput.inputactions
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

public partial class @ShopInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @ShopInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ShopInput"",
    ""maps"": [
        {
            ""name"": ""Shop"",
            ""id"": ""8d28a68e-5a15-4107-8bae-7a9beadc66f9"",
            ""actions"": [
                {
                    ""name"": ""OpenShop"",
                    ""type"": ""Button"",
                    ""id"": ""fbfcd331-734a-4d11-81b2-7115e87fc8f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""61b292d9-fd73-4365-9d63-ee219f9f121f"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenShop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Shop
        m_Shop = asset.FindActionMap("Shop", throwIfNotFound: true);
        m_Shop_OpenShop = m_Shop.FindAction("OpenShop", throwIfNotFound: true);
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

    // Shop
    private readonly InputActionMap m_Shop;
    private IShopActions m_ShopActionsCallbackInterface;
    private readonly InputAction m_Shop_OpenShop;
    public struct ShopActions
    {
        private @ShopInput m_Wrapper;
        public ShopActions(@ShopInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @OpenShop => m_Wrapper.m_Shop_OpenShop;
        public InputActionMap Get() { return m_Wrapper.m_Shop; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShopActions set) { return set.Get(); }
        public void SetCallbacks(IShopActions instance)
        {
            if (m_Wrapper.m_ShopActionsCallbackInterface != null)
            {
                @OpenShop.started -= m_Wrapper.m_ShopActionsCallbackInterface.OnOpenShop;
                @OpenShop.performed -= m_Wrapper.m_ShopActionsCallbackInterface.OnOpenShop;
                @OpenShop.canceled -= m_Wrapper.m_ShopActionsCallbackInterface.OnOpenShop;
            }
            m_Wrapper.m_ShopActionsCallbackInterface = instance;
            if (instance != null)
            {
                @OpenShop.started += instance.OnOpenShop;
                @OpenShop.performed += instance.OnOpenShop;
                @OpenShop.canceled += instance.OnOpenShop;
            }
        }
    }
    public ShopActions @Shop => new ShopActions(this);
    public interface IShopActions
    {
        void OnOpenShop(InputAction.CallbackContext context);
    }
}
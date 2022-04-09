// GENERATED AUTOMATICALLY FROM 'Assets/Settings/Input/GameInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInput"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""5827873f-5e59-4f45-859b-462789693f09"",
            ""actions"": [
                {
                    ""name"": ""MouseControlCamera"",
                    ""type"": ""Button"",
                    ""id"": ""c928f7d0-bdc3-495c-ac8f-ed648b01588a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateCamera"",
                    ""type"": ""Value"",
                    ""id"": ""f454e56d-124e-42ef-b151-70e52ce26c41"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""892c6aa6-b221-4afb-b0c9-e17ae1d20266"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseControlCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a625f401-eb56-4b0c-ba6d-5c9df6a59e3a"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=2,y=2)"",
                    ""groups"": """",
                    ""action"": ""RotateCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GamePlay
        m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
        m_GamePlay_MouseControlCamera = m_GamePlay.FindAction("MouseControlCamera", throwIfNotFound: true);
        m_GamePlay_RotateCamera = m_GamePlay.FindAction("RotateCamera", throwIfNotFound: true);
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

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private IGamePlayActions m_GamePlayActionsCallbackInterface;
    private readonly InputAction m_GamePlay_MouseControlCamera;
    private readonly InputAction m_GamePlay_RotateCamera;
    public struct GamePlayActions
    {
        private @GameInput m_Wrapper;
        public GamePlayActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseControlCamera => m_Wrapper.m_GamePlay_MouseControlCamera;
        public InputAction @RotateCamera => m_Wrapper.m_GamePlay_RotateCamera;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                @MouseControlCamera.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMouseControlCamera;
                @MouseControlCamera.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMouseControlCamera;
                @MouseControlCamera.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMouseControlCamera;
                @RotateCamera.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRotateCamera;
                @RotateCamera.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRotateCamera;
                @RotateCamera.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRotateCamera;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseControlCamera.started += instance.OnMouseControlCamera;
                @MouseControlCamera.performed += instance.OnMouseControlCamera;
                @MouseControlCamera.canceled += instance.OnMouseControlCamera;
                @RotateCamera.started += instance.OnRotateCamera;
                @RotateCamera.performed += instance.OnRotateCamera;
                @RotateCamera.canceled += instance.OnRotateCamera;
            }
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);
    public interface IGamePlayActions
    {
        void OnMouseControlCamera(InputAction.CallbackContext context);
        void OnRotateCamera(InputAction.CallbackContext context);
    }
}

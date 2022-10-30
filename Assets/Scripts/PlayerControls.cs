// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""MoveMap"",
            ""id"": ""9f0755c7-aa52-4fd2-b1b7-7d2c51e82a8a"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""0869d69e-0138-493f-9482-a1f59e494ae0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""33c8d1af-bf3c-412d-8c87-278aa6df6988"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveCam"",
                    ""type"": ""Button"",
                    ""id"": ""b5d7a189-7fe3-48ea-b59d-4cc51a1e85fa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""f0782104-8eab-46cd-b377-ba594778a3b1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e3c4db3b-9575-46be-9799-975f6de3995a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMainSchema"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f868c47b-de67-4f92-9067-25771f87e343"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMainSchema"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ca461ccb-e60c-4f9a-8186-6fb2cbc876f3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMainSchema"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4d2c391c-8a45-4b70-a28f-5e82332297d8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMainSchema"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0f85dc8b-3e24-4458-8583-e18febcc675d"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""KeyboardMainSchema"",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardMainSchema"",
            ""bindingGroup"": ""KeyboardMainSchema"",
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
        // MoveMap
        m_MoveMap = asset.FindActionMap("MoveMap", throwIfNotFound: true);
        m_MoveMap_Move = m_MoveMap.FindAction("Move", throwIfNotFound: true);
        m_MoveMap_Exit = m_MoveMap.FindAction("Exit", throwIfNotFound: true);
        m_MoveMap_MoveCam = m_MoveMap.FindAction("MoveCam", throwIfNotFound: true);
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

    // MoveMap
    private readonly InputActionMap m_MoveMap;
    private IMoveMapActions m_MoveMapActionsCallbackInterface;
    private readonly InputAction m_MoveMap_Move;
    private readonly InputAction m_MoveMap_Exit;
    private readonly InputAction m_MoveMap_MoveCam;
    public struct MoveMapActions
    {
        private @PlayerControls m_Wrapper;
        public MoveMapActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_MoveMap_Move;
        public InputAction @Exit => m_Wrapper.m_MoveMap_Exit;
        public InputAction @MoveCam => m_Wrapper.m_MoveMap_MoveCam;
        public InputActionMap Get() { return m_Wrapper.m_MoveMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MoveMapActions set) { return set.Get(); }
        public void SetCallbacks(IMoveMapActions instance)
        {
            if (m_Wrapper.m_MoveMapActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MoveMapActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MoveMapActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MoveMapActionsCallbackInterface.OnMove;
                @Exit.started -= m_Wrapper.m_MoveMapActionsCallbackInterface.OnExit;
                @Exit.performed -= m_Wrapper.m_MoveMapActionsCallbackInterface.OnExit;
                @Exit.canceled -= m_Wrapper.m_MoveMapActionsCallbackInterface.OnExit;
                @MoveCam.started -= m_Wrapper.m_MoveMapActionsCallbackInterface.OnMoveCam;
                @MoveCam.performed -= m_Wrapper.m_MoveMapActionsCallbackInterface.OnMoveCam;
                @MoveCam.canceled -= m_Wrapper.m_MoveMapActionsCallbackInterface.OnMoveCam;
            }
            m_Wrapper.m_MoveMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Exit.started += instance.OnExit;
                @Exit.performed += instance.OnExit;
                @Exit.canceled += instance.OnExit;
                @MoveCam.started += instance.OnMoveCam;
                @MoveCam.performed += instance.OnMoveCam;
                @MoveCam.canceled += instance.OnMoveCam;
            }
        }
    }
    public MoveMapActions @MoveMap => new MoveMapActions(this);
    private int m_KeyboardMainSchemaSchemeIndex = -1;
    public InputControlScheme KeyboardMainSchemaScheme
    {
        get
        {
            if (m_KeyboardMainSchemaSchemeIndex == -1) m_KeyboardMainSchemaSchemeIndex = asset.FindControlSchemeIndex("KeyboardMainSchema");
            return asset.controlSchemes[m_KeyboardMainSchemaSchemeIndex];
        }
    }
    public interface IMoveMapActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnExit(InputAction.CallbackContext context);
        void OnMoveCam(InputAction.CallbackContext context);
    }
}

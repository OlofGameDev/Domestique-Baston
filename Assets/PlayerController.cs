// GENERATED AUTOMATICALLY FROM 'Assets/PlayerController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerController"",
    ""maps"": [
        {
            ""name"": ""Player1"",
            ""id"": ""42d151b5-d09e-41d2-817c-bccff811983e"",
            ""actions"": [
                {
                    ""name"": ""AttackPunch"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ccb3bb09-e4f3-4604-9db3-9688812cb98c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Hold,Press(behavior=1)""
                },
                {
                    ""name"": ""Walk"",
                    ""type"": ""Value"",
                    ""id"": ""d0a9cae0-97ba-4c8e-be0c-e3c5ac83e7ac"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AttackKick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""839d467f-0159-4b5f-88ad-20b614b56c3f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Hold,Press(behavior=1)""
                },
                {
                    ""name"": ""AttackRanged"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9f132009-e830-4a34-b45b-8a07aa0a2182"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Hold,Press(behavior=1)""
                },
                {
                    ""name"": ""Block"",
                    ""type"": ""Button"",
                    ""id"": ""34b98994-190c-41ec-990e-130ce6f7dc06"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""06e27b0e-badc-4ca6-bca6-3f6852f54da8"",
                    ""path"": ""<HID::Microntek              USB Joystick          >/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackPunch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55762bcb-0021-4780-a24f-b7b87f327eb2"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackPunch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""42d46b83-e91e-4a45-bf52-b6b9f659f559"",
                    ""path"": ""<HID::Microntek              USB Joystick          >/stick"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""9e4b1bf1-1ad5-43e4-a08f-b72cb90886e5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""d737a45b-8872-478f-aa97-8a33a8b7d8f3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""a53ac283-6631-488b-aa20-777550d12150"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""2500b288-15ce-4843-b9d0-69c44d3aa204"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""a389aa84-09e1-4890-b8cf-3a2de478880e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2834eb37-d13a-4473-bbfc-8e4689600ab5"",
                    ""path"": ""<HID::Microntek              USB Joystick          >/button4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackKick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""624e535c-9c22-4656-bb7b-bde4b7303171"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackKick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""534c1145-06ec-48c0-9a90-4295413c17b1"",
                    ""path"": ""<HID::Microntek              USB Joystick          >/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackRanged"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4cb52cf7-adb2-4a2f-9e11-a10864f0fdb3"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackRanged"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""531a11d9-4f58-4a2d-8fed-c450f3a69be4"",
                    ""path"": ""<HID::Microntek              USB Joystick          >/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a44e8bf3-0866-4c67-a9ad-ddcd2d8f72a6"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player1
        m_Player1 = asset.FindActionMap("Player1", throwIfNotFound: true);
        m_Player1_AttackPunch = m_Player1.FindAction("AttackPunch", throwIfNotFound: true);
        m_Player1_Walk = m_Player1.FindAction("Walk", throwIfNotFound: true);
        m_Player1_AttackKick = m_Player1.FindAction("AttackKick", throwIfNotFound: true);
        m_Player1_AttackRanged = m_Player1.FindAction("AttackRanged", throwIfNotFound: true);
        m_Player1_Block = m_Player1.FindAction("Block", throwIfNotFound: true);
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

    // Player1
    private readonly InputActionMap m_Player1;
    private IPlayer1Actions m_Player1ActionsCallbackInterface;
    private readonly InputAction m_Player1_AttackPunch;
    private readonly InputAction m_Player1_Walk;
    private readonly InputAction m_Player1_AttackKick;
    private readonly InputAction m_Player1_AttackRanged;
    private readonly InputAction m_Player1_Block;
    public struct Player1Actions
    {
        private @PlayerController m_Wrapper;
        public Player1Actions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @AttackPunch => m_Wrapper.m_Player1_AttackPunch;
        public InputAction @Walk => m_Wrapper.m_Player1_Walk;
        public InputAction @AttackKick => m_Wrapper.m_Player1_AttackKick;
        public InputAction @AttackRanged => m_Wrapper.m_Player1_AttackRanged;
        public InputAction @Block => m_Wrapper.m_Player1_Block;
        public InputActionMap Get() { return m_Wrapper.m_Player1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player1Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer1Actions instance)
        {
            if (m_Wrapper.m_Player1ActionsCallbackInterface != null)
            {
                @AttackPunch.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAttackPunch;
                @AttackPunch.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAttackPunch;
                @AttackPunch.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAttackPunch;
                @Walk.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnWalk;
                @AttackKick.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAttackKick;
                @AttackKick.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAttackKick;
                @AttackKick.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAttackKick;
                @AttackRanged.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAttackRanged;
                @AttackRanged.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAttackRanged;
                @AttackRanged.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAttackRanged;
                @Block.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnBlock;
                @Block.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnBlock;
                @Block.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnBlock;
            }
            m_Wrapper.m_Player1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @AttackPunch.started += instance.OnAttackPunch;
                @AttackPunch.performed += instance.OnAttackPunch;
                @AttackPunch.canceled += instance.OnAttackPunch;
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @AttackKick.started += instance.OnAttackKick;
                @AttackKick.performed += instance.OnAttackKick;
                @AttackKick.canceled += instance.OnAttackKick;
                @AttackRanged.started += instance.OnAttackRanged;
                @AttackRanged.performed += instance.OnAttackRanged;
                @AttackRanged.canceled += instance.OnAttackRanged;
                @Block.started += instance.OnBlock;
                @Block.performed += instance.OnBlock;
                @Block.canceled += instance.OnBlock;
            }
        }
    }
    public Player1Actions @Player1 => new Player1Actions(this);
    public interface IPlayer1Actions
    {
        void OnAttackPunch(InputAction.CallbackContext context);
        void OnWalk(InputAction.CallbackContext context);
        void OnAttackKick(InputAction.CallbackContext context);
        void OnAttackRanged(InputAction.CallbackContext context);
        void OnBlock(InputAction.CallbackContext context);
    }
}

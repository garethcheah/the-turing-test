using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Trying new input system: https://docs.unity3d.com/Packages/com.unity.inputsystem@1.7/manual/Workflow-ActionsAsset.html
// This class is to be replaced with Player Input from the new input system.

// Execute this before all other scripts
[DefaultExecutionOrder(-100)]
public class PlayerInput : MonoBehaviour // Singleton
{
    public static PlayerInput instance;

    [SerializeField] private InputActionAsset _actions;

    private InputAction _moveAction;
    private InputAction _rotateAction;
    private InputAction _jumpAction;
    private InputAction _lookAction;
    private InputAction _shootAction;
    private InputAction _sprintAction;
    private InputAction _interactAction;
    private InputAction _changeWeaponAction;

    public float Vertical
    {
        get
        {
            return _moveAction.ReadValue<Vector2>().y;
        }
    }

    public Vector2 MoveInput
    {
        get
        {
            return _moveAction.ReadValue<Vector2>();
        }
    }

    public float RotateInput
    {
        get
        {
            return _rotateAction.ReadValue<float>();
        }
    }

    public float LookInput
    {
        get
        {
            return _lookAction.ReadValue<float>();
        }
    }

    public bool SprintHeld
    {
        get
        {
            return _sprintAction.inProgress;
        }
    }

    public bool JumpPressed
    {
        get
        {
            return _jumpAction.triggered;
        }
    }

    public bool InteractPressed
    {
        get
        {
            return _interactAction.triggered;
        }
    }

    public bool ShootPressed
    {
        get
        {
            return _shootAction.triggered;
        }
    }

    public bool ChangeWeaponPressed
    {
        get
        {
            return _changeWeaponAction.triggered;
        }
    }

    public bool CommandPressed { get; private set; }

    public void EnablePlayerActions()
    {
        _actions.FindActionMap("PlayerActions").Enable();
    }

    public void DisablePlayerActions()
    {
        _actions.FindActionMap("PlayerActions").Disable();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        _moveAction = _actions.FindActionMap("PlayerActions").FindAction("Move");
        _rotateAction = _actions.FindActionMap("PlayerActions").FindAction("Rotate");
        _jumpAction = _actions.FindActionMap("PlayerActions").FindAction("Jump");
        _lookAction = _actions.FindActionMap("PlayerActions").FindAction("Look");
        _shootAction = _actions.FindActionMap("PlayerActions").FindAction("Shoot");
        _sprintAction = _actions.FindActionMap("PlayerActions").FindAction("Sprint");
        _interactAction = _actions.FindActionMap("PlayerActions").FindAction("Interact");
        _changeWeaponAction = _actions.FindActionMap("PlayerActions").FindAction("ChangeWeapon");
    }
}

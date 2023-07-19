using System;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour {
    public event EventHandler OnPlayerJump;
    public event EventHandler OnPlayerChangeEnvironment;
    private GameInputActions inputActions;

    void Awake() {
        inputActions = new GameInputActions();
    }

    private void Start() {
        inputActions.Enable();
        inputActions.Player.Jump.performed += OnPlayerJumpPerformed;
        inputActions.Player.EnvironmentChange.performed += OnPlayerChangeEnvironmentPerformed;
    }

    private void OnDestroy() {
        inputActions.Player.Jump.performed -= OnPlayerJumpPerformed;
        inputActions.Player.EnvironmentChange.performed -= OnPlayerChangeEnvironmentPerformed;
        inputActions.Dispose();
    }

    private void OnPlayerJumpPerformed(InputAction.CallbackContext callbackContext) {
        OnPlayerJump.Invoke(this, EventArgs.Empty);
    }
    private void OnPlayerChangeEnvironmentPerformed(InputAction.CallbackContext callbackContext)
    {
        OnPlayerChangeEnvironment.Invoke(this, EventArgs.Empty);
    }
    public float GetHorizontalMovement() {
        float input = inputActions.Player.Movement.ReadValue<float>();
        return input;
    }
    public float GetVerticalMovement() {
        float input = inputActions.Player.Climb.ReadValue<float>();
        return input;
    }
}

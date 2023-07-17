using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour {
    public event EventHandler OnPlayerJump;

    private GameInputActions inputActions;
    void Awake() {
        inputActions = new GameInputActions();
    }

    private void Start() {
        inputActions.Enable();
        inputActions.Player.Jump.performed += OnPlayerJumpPerformed;
    }

    private void OnDestroy() {
        inputActions.Player.Jump.performed -= OnPlayerJumpPerformed;
        inputActions.Dispose();
    }

    private void OnPlayerJumpPerformed(InputAction.CallbackContext callbackContext) {
        OnPlayerJump.Invoke(this, EventArgs.Empty);
    }

    public float GetMovement() {
        float input = inputActions.Player.Movement.ReadValue<float>();
        return input;
    }
}

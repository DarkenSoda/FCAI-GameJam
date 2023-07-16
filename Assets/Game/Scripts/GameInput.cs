using UnityEngine;

public class GameInput : MonoBehaviour
{
    private GameInputActions inputActions;
    void Awake()
    {
        inputActions = new GameInputActions();
    }
    private void Start()
    {
        inputActions.Enable();
    }
    public float GetMovement()
    {
        float input = inputActions.Player.Movement.ReadValue<float>();
        return input;
    }
    private void OnDestroy()
    {
        inputActions.Dispose();
    }
}

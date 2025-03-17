using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    private PlayerInput playerInput;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    public Vector2 GetMovementInput()
    {
        InputAction moveAction = playerInput.actions.FindAction("Movement");
        return moveAction.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        InputAction lookAction = playerInput.actions.FindAction("Look");
        return lookAction.ReadValue<Vector2>();
    }

    public bool IsPlayerGrabbing()
    {
        InputAction pickupAction = playerInput.actions.FindAction("Pickup");
        return pickupAction.IsPressed();
    }

    public Ray GetCrosshairPoint()
    {
        return Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
    }
}

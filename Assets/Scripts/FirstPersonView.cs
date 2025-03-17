using UnityEngine;

public class FirstPersonView : MonoBehaviour
{
    [SerializeField]
    private Transform cameraHolder;
    [SerializeField, Range(0f, 2f)]
    private float sensitivity = 1f;
    [SerializeField, Range(0f, 100f)]
    private float smoothing = 50f;

    private InputManager inputManager;
    private Vector3 playerOrientation;
    private Vector2 smoothedDelta;

    private void Start()
    {
        inputManager = InputManager.Instance;
        HideCursor();
    }

    private void Update()
    {
        HandleLook();
    }

    private void HandleLook()
    {
        Vector2 mouseDelta = inputManager.GetMouseDelta() * sensitivity;
        smoothedDelta = Vector2.Lerp(smoothedDelta, mouseDelta, 1f / smoothing);

        playerOrientation.x += mouseDelta.x;
        playerOrientation.y -= mouseDelta.y;
        playerOrientation.x = Mathf.Repeat(playerOrientation.x + 180f, 360f) - 180f;
        playerOrientation.y = Mathf.Clamp(playerOrientation.y, -30f, 30f);

        cameraHolder.rotation = Quaternion.Euler(playerOrientation.y, cameraHolder.rotation.eulerAngles.y, 0f);
        transform.rotation = Quaternion.Euler(0f, playerOrientation.x, 0f);
    }

    private void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

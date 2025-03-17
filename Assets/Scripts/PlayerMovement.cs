using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    private Rigidbody rb;
    private InputManager inputManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        inputManager = InputManager.Instance;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 input = inputManager.GetMovementInput();
        Debug.Log("Input Value: " + input);

        if (input == Vector2.zero)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }

        Vector3 direction = new Vector3(input.x, 0, input.y);
        Vector3 force = direction * moveSpeed * Time.deltaTime;
        // Preserve the vertical velocity component.
        force.y = rb.velocity.y;
        rb.AddRelativeForce(force);
    }
}

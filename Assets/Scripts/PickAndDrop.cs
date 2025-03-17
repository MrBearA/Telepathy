using UnityEngine;

public class PickAndDrop : MonoBehaviour
{
    [SerializeField]
    private Transform objectHolder;
    [SerializeField]
    private float objectMoveSpeed = 10f;
    [SerializeField]
    private float throwForce = 10f;

    private InputManager inputManager;
    private Transform grabbedObject;

    private void Start()
    {
        inputManager = InputManager.Instance;
    }

    private void Update()
    {
        HandleGrab();
    }

    private void HandleGrab()
    {
        Ray ray = inputManager.GetCrosshairPoint();
        float maxDistance = 100f;

        if (!inputManager.IsPlayerGrabbing())
        {
            ReleaseObject();
            return;
        }

        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance)
            && hit.transform.CompareTag("Object")
            && Vector3.Distance(transform.position, hit.point) <= maxDistance
            && grabbedObject == null)
        {
            grabbedObject = hit.transform;
            grabbedObject.SetParent(objectHolder);
        }

        if (grabbedObject != null)
        {
            Vector3 targetPosition = objectHolder.position;
            grabbedObject.position = Vector3.MoveTowards(grabbedObject.position, targetPosition, objectMoveSpeed * Time.deltaTime);

            if (Vector3.Distance(grabbedObject.position, targetPosition) <= 1f)
            {
                ThrowObject();
            }
        }
    }

    private void ReleaseObject()
    {
        if (grabbedObject != null)
        {
            grabbedObject.SetParent(null);
            grabbedObject = null;
        }
    }

    private void ThrowObject()
    {
        if (grabbedObject != null)
        {
            Vector3 throwDirection = objectHolder.forward;
            Rigidbody rb = grabbedObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = throwDirection * throwForce;
            }
            ReleaseObject();
        }
    }
}

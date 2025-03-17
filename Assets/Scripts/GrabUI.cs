using UnityEngine;
using TMPro;

public class GrabUI : MonoBehaviour
{
    [SerializeField]
    private float maxDistance = 100f;
    [SerializeField]
    private LayerMask grabbableLayer;

    private InputManager inputManager;
    private TextMeshProUGUI grabbableText;

    private void Start()
    {
        inputManager = InputManager.Instance;
        grabbableText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        UpdateGrabbableText();
    }

    private void UpdateGrabbableText()
    {
        Ray ray = inputManager.GetCrosshairPoint();
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, grabbableLayer))
        {
            if (!inputManager.IsPlayerGrabbing())
            {
                grabbableText.text = "Grab and throw";
            }
        }
        else
        {
            grabbableText.text = "";
        }
    }
}

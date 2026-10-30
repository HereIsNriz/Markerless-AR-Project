using UnityEngine;
using UnityEngine.InputSystem;

public class TapToCatchManager : MonoBehaviour
{
    [SerializeField] private Camera arCamera;
    [SerializeField] private float rayDistance = 20f;

    private void Awake()
    {
        if (arCamera == null)
            arCamera = Camera.main;
    }

    private void Update()
    {
        Vector2 screenPosition = new Vector2();
        bool tapped = false;

        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            screenPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            tapped = true;
        }
#if UNITY_EDITOR
        else if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            screenPosition = Mouse.current.position.ReadValue();
            tapped = true;
        }
#endif
        if (tapped)
            HandleTap(screenPosition);
    }

    private void HandleTap(Vector2 screenPosition)
    {
        if (arCamera == null)
            return;

        Ray ray = arCamera.ScreenPointToRay(screenPosition);

        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance, Physics.DefaultRaycastLayers, QueryTriggerInteraction.Collide))
        {
            AnimalCatchable animal = hit.collider.GetComponentInParent<AnimalCatchable>();

            if (animal != null)
                animal.RegisterTap();
        }
    }
}
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMouse : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] LayerMask interactableMask;
    private Transform currentSelection;

    public static bool interacting;

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame && currentSelection != null)
        {
            currentSelection.GetComponent<IInteractable>().OnInteractExit();
            currentSelection = null;
        }
        
        if (interacting) return;

        // Calculate mouse point ray
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = 10f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        // Debug.DrawRay(cam.transform.position, mousePos - transform.position);
        
        RaycastHit hit;
        Ray ray = new Ray(cam.transform.position, mousePos - transform.position);

        // Shoot raycast and check for interactables hit
        if (Physics.Raycast(ray, out hit, 5, interactableMask))
        {
            currentSelection = hit.transform;
            hit.transform.gameObject.GetComponent<ObjectHighlighter>().Highlight();

            // lmb click, interact with item
            if (Mouse.current.leftButton.wasPressedThisFrame) 
            {
                currentSelection.GetComponent<IInteractable>().OnInteract();
                currentSelection.GetComponent<ObjectHighlighter>().DeHighlight();
                interacting = true;
            }
        }

        // Raycast did not hit interactable & obj is highlighted
        else if (currentSelection != null)
        {
            currentSelection.GetComponent<ObjectHighlighter>().DeHighlight();
            currentSelection = null;
        }
    }

}

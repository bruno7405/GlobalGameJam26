using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMouse : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] LayerMask interactableMask;
    private Transform currentSelection;

    public static bool active = true;
    public static bool interacting;

    void Update()
    {
        if (!active) return;

        if ((Keyboard.current.escapeKey.wasPressedThisFrame || Keyboard.current.qKey.wasPressedThisFrame) && currentSelection != null)
        {
            currentSelection.GetComponent<IInteractable>().OnInteractExit();
            currentSelection = null;
        }

        Debug.Log(interacting);
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
            currentSelection?.GetComponent<ObjectHighlighter>().DeHighlight();
            currentSelection = hit.transform;
            hit.transform.gameObject.GetComponent<ObjectHighlighter>().Highlight();

            // lmb click, interact with item
            if (Mouse.current.leftButton.wasPressedThisFrame) 
            {
                Debug.Log("Interacting with " + currentSelection.name);
                interacting = true;
                currentSelection.GetComponent<ObjectHighlighter>().DeHighlight();
                currentSelection.GetComponent<IInteractable>().OnInteract();
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

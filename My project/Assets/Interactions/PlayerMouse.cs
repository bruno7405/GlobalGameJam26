using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMouse : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] LayerMask interactableMask;
    private Transform currentSelection;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = 10f;
        mousePos = camera.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(camera.transform.position, mousePos-transform.position);
        
        RaycastHit hit;
        Ray ray = new Ray(camera.transform.position, mousePos - transform.position);

        // Shoot raycast and check for interactables hit
        if (Physics.Raycast(ray, out hit, 5, interactableMask))
        {
            currentSelection = hit.transform;
            hit.transform.gameObject.GetComponent<ObjectHighlighter>().Highlight();
        }

        // Raycast did not hit interactable & an item is highlighted
        else if (currentSelection != null)
        {
            currentSelection.GetComponent<ObjectHighlighter>().DeHighlight();
            currentSelection = null;
        }
    }

}

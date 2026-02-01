using UnityEngine;

public class PhoneInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject phoneUI;

    public void OnInteract()
    {
        // Check if currently getting call
        // If not open UI normally
        phoneUI.SetActive(true);
    }

    public void OnInteractExit()
    {
        phoneUI.SetActive(false);
        PlayerMouse.interacting = false;
    }
}

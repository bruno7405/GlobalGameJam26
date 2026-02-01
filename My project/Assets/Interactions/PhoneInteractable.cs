using UnityEngine;

public class PhoneInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject phoneUI;

    PhoneManager phoneManager;

    private void Start()
    {
        phoneManager = GetComponent<PhoneManager>();
    }

    public void OnInteract()
    {
        // Check if currently getting call
        // If not open UI normally
        if (phoneManager.receivingCall) {
            phoneManager.PickUpCall();
        }
        else {
            phoneUI.SetActive(true);
        }
    }

    public void OnInteractExit()
    {
        phoneUI.SetActive(false);
        PlayerMouse.interacting = false;
    }
}

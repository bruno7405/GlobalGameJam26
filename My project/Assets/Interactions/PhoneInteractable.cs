using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class PhoneInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject phoneUI;
    [SerializeField] GameObject mainCinemachineCam;
    [SerializeField] GameObject phoneCinemachineCam;

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
            SwitchCamera(phoneCinemachineCam);
        }
        else {
            StartCoroutine(PanToPhone());
        }
    }

    public void OnInteractExit()
    {
        StopAllCoroutines();
        phoneUI.SetActive(false);
        PlayerMouse.interacting = false;
        StartCoroutine(PanToNormal());
    }

    private void SwitchCamera(GameObject cam)
    {
        cam.SetActive(false);
        cam.SetActive(true);
    }


    private IEnumerator PanToPhone()
    {
        SwitchCamera(phoneCinemachineCam);
        yield return new WaitForSeconds(1);
        phoneUI.SetActive(true);
    }

    private IEnumerator PanToNormal()
    {
        SwitchCamera(mainCinemachineCam);
        yield return new WaitForSeconds(1);
        phoneUI.SetActive(false);
    }
}

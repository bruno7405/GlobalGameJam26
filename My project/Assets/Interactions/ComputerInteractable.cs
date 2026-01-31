using System.Collections;
using UnityEngine;

public class ComputerInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject computerUI;

    [SerializeField] GameObject mainCinemachineCam;
    [SerializeField] GameObject computerCinemachineCam;

    public void OnInteract()
    {
        SwitchCamera(computerCinemachineCam);
        Invoke(nameof(ShowComputerUI), 1);
    }

    public void OnInteractExit()
    {
        SwitchCamera(mainCinemachineCam);
        StartCoroutine(HideComputerUI());
    }

    private void SwitchCamera(GameObject cam)
    {
        cam.SetActive(false);
        cam.SetActive(true);
    }

    private void ShowComputerUI()
    {
        computerUI.SetActive(true);
    }

    private IEnumerator HideComputerUI()
    {
        computerUI.SetActive(false);
        yield return new WaitForSeconds(1);
        PlayerMouse.interacting = false;
    }

}

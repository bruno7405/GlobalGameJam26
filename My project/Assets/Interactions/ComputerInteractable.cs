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
        StartCoroutine(ShowComputerUI());
    }

    public void OnInteractExit()
    {
        StopAllCoroutines();
        SwitchCamera(mainCinemachineCam);
        StartCoroutine(HideComputerUI());
    }

    private void SwitchCamera(GameObject cam)
    {
        cam.SetActive(false);
        cam.SetActive(true);
    }

    private IEnumerator ShowComputerUI()
    {
        yield return new WaitForSeconds(1);
        computerUI.SetActive(true);
    }

    private IEnumerator HideComputerUI()
    {
        computerUI.SetActive(false);
        yield return new WaitForSeconds(.25f);
        PlayerMouse.interacting = false;
    }

}

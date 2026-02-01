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
        //StartCoroutine(ShowComputerUI());
    }

    public void OnInteractExit()
    {
        StopAllCoroutines();
        StartCoroutine(ExitComputer());
    }

    private void SwitchCamera(GameObject cam)
    {
        cam.SetActive(false);
        cam.SetActive(true);
    }

    private IEnumerator ShowComputerUI()
    {
        yield return new WaitForSeconds(1);
        //computerUI.SetActive(true);
    }

    private IEnumerator ExitComputer()
    {
        //computerUI.SetActive(false);
        SwitchCamera(mainCinemachineCam);
        yield return new WaitForSeconds(.75f);
        PlayerMouse.interacting = false;
    }

}

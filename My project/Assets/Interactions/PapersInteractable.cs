using System.Collections;
using UnityEngine;

public class PapersInteractable : MonoBehaviour, IInteractable
{

    [SerializeField] GameObject agentProfilesUI;

    [SerializeField] GameObject mainCinemachineCam;
    [SerializeField] GameObject paperCinemachineCam;

    public void OnInteract()
    {
        SwitchCamera(paperCinemachineCam);
        StartCoroutine(ShowUI());
    }

    public void OnInteractExit()
    {
        StopAllCoroutines();
        SwitchCamera(mainCinemachineCam);
        StartCoroutine(HideUI());
    }

    private void SwitchCamera(GameObject cam)
    {
        cam.SetActive(false);
        cam.SetActive(true);
    }

    private IEnumerator ShowUI()
    {
        yield return new WaitForSeconds(1);
        agentProfilesUI.SetActive(true);
    }

    private IEnumerator HideUI()
    {
        agentProfilesUI.SetActive(false);
        yield return new WaitForSeconds(.25f);
        PlayerMouse.interacting = false;
    }
}

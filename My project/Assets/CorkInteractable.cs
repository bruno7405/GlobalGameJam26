using UnityEngine;
using System.Collections;

public class CorkInteractable : MonoBehaviour, IInteractable
{
    public GameObject mainCinemaCam;
    public GameObject corkboardCam;
    
    public void OnInteract()
    {
        SwitchCamera(corkboardCam);
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

    private IEnumerator ExitComputer()
    {
        //computerUI.SetActive(false);
        SwitchCamera(mainCinemaCam);
        yield return new WaitForSeconds(.75f);
        PlayerMouse.interacting = false;
    }
}

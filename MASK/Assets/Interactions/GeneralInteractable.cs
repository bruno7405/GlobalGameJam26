using System.Collections;
using UnityEngine;

public class GeneralInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject mainCinemachineCam;
    [SerializeField] GameObject objCnemachineCam;

    public void OnInteract()
    {
        SwitchCamera(objCnemachineCam);
    }

    public void OnInteractExit()
    {
        StopAllCoroutines();
        StartCoroutine(SwitchToMainCamera());
    }

    private void SwitchCamera(GameObject cam)
    {
        cam.SetActive(false);
        cam.SetActive(true);
    }

    private IEnumerator SwitchToMainCamera()
    {
        SwitchCamera(mainCinemachineCam);
        yield return new WaitForSeconds(.25f);
        PlayerMouse.interacting = false;
    }

}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
    public GameObject title, creators;
    
    void Start()
    {
        StartCoroutine(CreditsSequence());
    }

    IEnumerator CreditsSequence()
    {
        yield return new WaitForSeconds(1.5f);
        title.SetActive(false);
        creators.SetActive(true);
        yield return new WaitForSeconds(8);
        BlackScreenUI.Instance.FadeToBlack();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}

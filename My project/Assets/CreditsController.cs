using System.Collections;
using UnityEngine;

public class CreditsController : MonoBehaviour
{
    public GameObject title, creators;
    
    void Start()
    {
        StartCoroutine(CreditsSequence());
    }

    IEnumerator CreditsSequence()
    {
        yield return new WaitForSeconds(8);
        title.SetActive(false);
        creators.SetActive(true);
        yield return new WaitForSeconds(8);
        Application.Quit();
        Debug.Log("QUIT THE GAME YA");
    }
}

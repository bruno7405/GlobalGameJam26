using System.Collections;
using UnityEngine;

public class CreditsController : MonoBehaviour
{
    public GameObject title, creators, developers, writers, arts, usedAssets;
    
    void Start()
    {
        
    }

    IEnumerator CreditsSequence()
    {
        yield return new WaitForSeconds(5);
    }
}

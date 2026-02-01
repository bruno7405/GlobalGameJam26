using System.Collections;
using UnityEngine;

public class TutorialState : State
{
    public PhoneRinger phoneRinger;
    public float timeBeforeRing = 5f;
    
    public override void OnStart()
    {
        Debug.Log("Tutorial state started.");

        StartCoroutine(nameof(sequencePhone));
        //throw new System.NotImplementedException();
    }

    private IEnumerator sequencePhone()
    {
        yield return new WaitForSeconds(timeBeforeRing);
        phoneRinger.StartRinger();
    }

    public override void OnUpdate()
    {
        //throw new System.NotImplementedException();
    }
}

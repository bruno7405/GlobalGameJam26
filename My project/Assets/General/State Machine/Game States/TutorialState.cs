using System.Collections;
using UnityEngine;

public class TutorialState : State
{
    public PhoneManager phoneManager;
    public float timeBeforeRing = 5f;
    public string tutorialCallAudio = "debug_call";
    public float tutorialCallLength = 11f;

    public State nextState;
    
    public override void OnStart()
    {
        Debug.Log("Tutorial state started.");

        StartCoroutine(nameof(sequencePhone));
        //throw new System.NotImplementedException();
    }

    private IEnumerator sequencePhone()
    {
        yield return new WaitForSeconds(timeBeforeRing);
        phoneManager.StartRinger();
        phoneManager.audioDialogue = tutorialCallAudio;
        phoneManager.callLength = tutorialCallLength;
    }

    public override void OnUpdate()
    {
        //throw new System.NotImplementedException();
    }

    public override void GoToNextState()
    {
        StateMachineManager.Instance.SetNewState(nextState);
    }
}

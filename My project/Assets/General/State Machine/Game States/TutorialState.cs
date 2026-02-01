using System.Collections;
using UnityEngine;

public class TutorialState : State
{
    public PhoneManager phoneManager;
    public float timeBeforeRing = 3f;
    public string tutorialCallAudio = "debug_call";
    public float tutorialCallLength = 11f;
    
    public override void OnStart()
    {
        Debug.Log("Tutorial state started.");

        StartCoroutine(nameof(SequencePhone));
        //throw new System.NotImplementedException();
        BlackScreenUI.Instance.Black();
    }

    private IEnumerator SequencePhone()
    {
        PlayerMouse.active = false;
        yield return new WaitForSeconds(timeBeforeRing);
        BlackScreenUI.Instance.FadeToNormal();
        PlayerMouse.active = true;
        phoneManager.StartRinger();
        phoneManager.incomingCallAudio = tutorialCallAudio;
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

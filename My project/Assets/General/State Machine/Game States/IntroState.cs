using UnityEngine;

public class IntroState : State
{
    public PhoneManager phoneManager;
    public string secretaryCallAudio = "debug_call";
    public float secretaryCallLength = 5f;
    
    public override void OnStart()
    {
        Debug.Log("Intro state started.");
        phoneManager.outgoingCallAudio = secretaryCallAudio;
        phoneManager.callLength = 5f;
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

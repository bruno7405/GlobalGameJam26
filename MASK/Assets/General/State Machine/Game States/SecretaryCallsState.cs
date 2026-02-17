using UnityEngine;

public class SecretaryCallsState : State
{
    public PhoneManager phoneManager;
    public string secretarySecondCallAudio = "debug_call";
    public float secretarySecondCallLength = 5f;
    
    
    public override void GoToNextState()
    {
        StateMachineManager.Instance.SetNewState(nextState);
    }

    public override void OnStart()
    {
        Debug.Log("Second Phone state started.");
        phoneManager.StartRinger();
        phoneManager.outgoingCallAudio = secretarySecondCallAudio;
        phoneManager.callLength = secretarySecondCallLength;
    }

    public override void OnUpdate()
    {
        //throw new System.NotImplementedException();
    }
}

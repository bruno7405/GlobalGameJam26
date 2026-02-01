using UnityEngine;

public class ClimaxState : State
{
    public PhoneManager phoneManager;
    public string susYellowCall = "debug_call";
    public float callLength = 5f;
    
    public override void GoToNextState()
    {
        StateMachineManager.Instance.SetNewState(nextState);
    }

    public override void OnStart()
    {
        Debug.Log("Yellow Phone 2 state started.");
        phoneManager.StartRinger();
        phoneManager.outgoingCallAudio = susYellowCall;
        phoneManager.callLength = callLength;
    }

    public override void OnUpdate()
    {
        // throw new System.NotImplementedException();
    }
}

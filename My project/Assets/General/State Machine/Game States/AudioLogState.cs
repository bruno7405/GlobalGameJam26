using UnityEngine;

public class AudioLogState : State
{
    public string audioLog = "debug_call";
    public float audioLength = 5; // Change this to match the length of the audio log, phone will ring after

    public ComputerManager computerManager;
    
    public override void GoToNextState()
    {
        StateMachineManager.Instance.SetNewState(nextState);
    }

    public override void OnStart()
    {
        Debug.Log("Audio State!");

        computerManager.audioFile = audioLog;
        computerManager.audioLength = audioLength;
        //throw new System.NotImplementedException();
    }

    public override void OnUpdate()
    {
        //throw new System.NotImplementedException();
    }
}

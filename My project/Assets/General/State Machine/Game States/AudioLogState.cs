using UnityEngine;

public class AudioLogState : State
{
    public string audioLog = "debug_call";
    public float audioLength = 5;

    public ComputerManager computerManager;
    public CorkBoardManager corkBoardManager;
    
    public override void GoToNextState()
    {
        StateMachineManager.Instance.SetNewState(nextState);
    }

    public override void OnStart()
    {
        Debug.Log("Audio State!");
        corkBoardManager.AddAudCode();
        computerManager.audioFile = audioLog;
        computerManager.audioLength = audioLength;
        //throw new System.NotImplementedException();
    }

    public override void OnUpdate()
    {
        //throw new System.NotImplementedException();
    }
}

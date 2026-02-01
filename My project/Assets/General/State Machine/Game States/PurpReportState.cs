using UnityEngine;

public class PurpReportState : State
{
    public GameObject purpleFile;
    public string logFileName;
    
    public override void GoToNextState()
    {
        StateMachineManager.Instance.SetNewState(nextState);
        BottomChecker.OnScrolledToBottom -= HandleScrollBottom;
    }

    public override void OnStart()
    {
        purpleFile.SetActive(true);
        BottomChecker.OnScrolledToBottom += HandleScrollBottom;
    }

    void HandleScrollBottom(string id)
    {
        if (id == logFileName)
        {
            StateMachineManager.Instance.SetNewState(nextState);
            GoToNextState();
        }
    }

    public override void OnUpdate()
    {
        //throw new System.NotImplementedException();
    }
}

using UnityEngine;

public class PurpReportState : State
{
    public GameObject purpleFile;
    public string logFileName;
    
    public override void GoToNextState()
    {
        StateMachineManager.Instance.SetNewState(nextState);
        //BottomChecker.OnScrolledToBottom -= HandleScrollBottom;
    }

    public void TryGoNextState()
    {
        if (StateMachineManager.Instance.currentState.GetType() == typeof(PurpReportState))
        {
            GoToNextState();
        }
    }

    public override void OnStart()
    {
        purpleFile.SetActive(true);
        Debug.Log("Purple file state started!");
        //BottomChecker.OnScrolledToBottom += HandleScrollBottom;
    }

    

    public override void OnUpdate()
    {
        //throw new System.NotImplementedException();
    }
}

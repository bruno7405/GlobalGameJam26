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

    public override void OnStart()
    {
        purpleFile.SetActive(true);
        Debug.Log("Purple file state started!");
        //BottomChecker.OnScrolledToBottom += HandleScrollBottom;
    }

    // void HandleScrollBottom(string id)
    // {
    //     Debug.Log("id:" + id);
    //     Debug.Log("name:" + logFileName);
    //     if (id == logFileName)
    //     {
    //         GoToNextState();
    //     }
    // }

    public override void OnUpdate()
    {
        //throw new System.NotImplementedException();
    }
}

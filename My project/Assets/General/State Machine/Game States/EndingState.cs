using UnityEngine;

public class EndingState : State
{
    public override void GoToNextState()
    {
        // I SHOULD NEVER BE CALLED :D
        Debug.LogError("Ending state cannot progress further.");
        //throw new System.NotImplementedException();
    }

    public override void OnStart()
    {
        // Knocking event...
        // Set grabbing the gun to close UI...
    }

    public override void OnUpdate()
    {
        throw new System.NotImplementedException();
    }
}

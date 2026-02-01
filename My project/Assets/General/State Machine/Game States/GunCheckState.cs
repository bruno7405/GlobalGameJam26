using UnityEngine;

public class GunCheckState : State
{
    public override void GoToNextState()
    {
        StateMachineManager.Instance.SetNewState(nextState);
    }

    public override void OnStart()
    {
        //throw new System.NotImplementedException();   // kinda doesn't need to do anything, just wait for player to click the gun
    }

    public override void OnUpdate()
    {
        //throw new System.NotImplementedException();
    }
}

using UnityEngine;

public class GunCheckTwoState : State
{
    [SerializeField] GameObject pickUpGunText;

    public override void GoToNextState()
    {
        // pickUpGunText.SetActive(false);
        StateMachineManager.Instance.SetNewState(nextState);
    }

    public override void OnStart()
    {
        // PICK UP THE GUN
        pickUpGunText.SetActive(true);
        AudioManager.instance.PlayLoop("door_knocking");
    }

    public override void OnUpdate()
    {
        // throw new System.NotImplementedException();
    }
}

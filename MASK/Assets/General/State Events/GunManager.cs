
using UnityEngine;

public class GunManager : MonoBehaviour
{
    // Somehow trigger this function from another script to progress the statemachine
    public void CheckGun()
    {
        if (StateMachineManager.Instance.currentState.GetType() == typeof(GunCheckState))
        {
            StateMachineManager.Instance.currentState.GoToNextState();
        }
    }
}

using System;
using UnityEngine;

public class ComputerManager : MonoBehaviour
{
    public GameObject loginScreen, desktop;

    public State introState; 
    
    void Start()
    {
        loginScreen.SetActive(true);
        desktop.SetActive(false);
    }

    public void Login(string input)
    {
        if (input == "3101")
        {
            loginScreen.SetActive(false);
            desktop.SetActive(true);
            
            if (StateMachineManager.Instance.currentState.GetType() == typeof(TutorialState)) {
                StateMachineManager.Instance.SetNewState(introState);
            }
        }
    }
}

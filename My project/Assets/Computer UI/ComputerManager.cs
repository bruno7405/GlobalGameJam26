using System;
using UnityEngine;

public class ComputerManager : MonoBehaviour
{
    public GameObject loginScreen, desktop;
    
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
        }
    }
}

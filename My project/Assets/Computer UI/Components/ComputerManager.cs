using System;
using System.Collections;
using UnityEngine;

public class ComputerManager : MonoBehaviour
{
    public GameObject loginScreen, desktop;
    [HideInInspector] public string audioFile;
    [HideInInspector] public float audioLength;
    
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

    public void PlayAudioLog()
    {
        AudioManager.instance.PlayOneShot(audioFile);
        StartCoroutine(nameof(WaitForAudio));
    }

    IEnumerator WaitForAudio()
    {
        yield return new WaitForSeconds(audioLength); //fix
        if (StateMachineManager.Instance.currentState.GetType() == typeof(AudioLogState)) {
            StateMachineManager.Instance.currentState.GoToNextState();
        }
    }
}

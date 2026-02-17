using System;
using System.Collections;
using UnityEngine;

public class ComputerManager : MonoBehaviour
{
    public GameObject loginScreen, desktop;
    [HideInInspector] public string audioFile;
    [HideInInspector] public float audioLength;

    private Coroutine currentCor;

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
        AudioManager.instance.Play(audioFile);
        currentCor = StartCoroutine(nameof(WaitForAudio));
    }

    public void StopPlayingAudioLog()
    {
        AudioManager.instance.StopSource(audioFile);
        StopCoroutine(currentCor);
        Debug.Log("stopped corutine");
    }

    IEnumerator WaitForAudio()
    {
        yield return new WaitForSeconds(audioLength * 0.7f);
        StartCoroutine(AudioLogGoNextState());
    }

    IEnumerator AudioLogGoNextState()
    {
        Debug.Log("Go to next state from audio log");
        yield return new WaitForSeconds(audioLength * 0.3f); 
        if (StateMachineManager.Instance.currentState.GetType() == typeof(AudioLogState))
        {
            StateMachineManager.Instance.currentState.GoToNextState();
        }
    }
}

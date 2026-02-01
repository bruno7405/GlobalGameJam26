using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingState : State
{
    public Dialogue endingDialogue;
    public float fadeToBlackTime = 1;
    public string gunshotSound = "silver_shoot";
    public float gunSoundTime = 5;

    public override void GoToNextState()
    {
        // I SHOULD NEVER BE CALLED :D
        Debug.LogError("Ending state cannot progress further.");
        //throw new System.NotImplementedException();
    }

    public override void OnStart()
    {
        StartCoroutine(EndingSequence());
    }

    public IEnumerator EndingSequence()
    {
        BlackScreenUI.Instance.FadeToBlack();
        yield return new WaitForSeconds(fadeToBlackTime);

        DialogueManager.Instance.StartDialogue(endingDialogue);
        DialogueManager.Instance.onDialogFinished += SwapToCredits;

    }

    public void SwapToCredits()
    {
        StartCoroutine(GoToCredits());
    }

    IEnumerator GoToCredits()
    {
        AudioManager.instance.PlayOneShot(gunshotSound);
        yield return new WaitForSeconds(gunSoundTime);

        SceneManager.LoadScene("Credits");
    }

    public override void OnUpdate()
    {
        throw new System.NotImplementedException();
    }
}

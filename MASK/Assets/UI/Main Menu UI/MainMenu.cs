using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button exitButton;

    [SerializeField] BlackScreenUI blackScreenUI;

    private bool buttonPressed = false;

    private void OnEnable()
    {
        startButton.onClick.AddListener(OnStartPressed);
        exitButton.onClick.AddListener(OnExitPressed);
    }

    private void OnDisable()
    {
        startButton.onClick.RemoveListener(OnStartPressed);
        exitButton.onClick.RemoveListener(OnExitPressed);
    }

    private void OnStartPressed()
    {
        if (buttonPressed) return;

        StartCoroutine(StartingSequence());
    }

    IEnumerator StartingSequence()
    {
        buttonPressed = true;
        blackScreenUI.FadeToBlack();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Office");
    }

    private void OnExitPressed()
    {
       Application.Quit();
    }

}

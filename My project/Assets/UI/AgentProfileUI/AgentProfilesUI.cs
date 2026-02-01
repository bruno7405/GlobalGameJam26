using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentProfilesUI : MonoBehaviour
{
    [SerializeField] List<GameObject> profiles = new List<GameObject>();
    int selectedProfileIndex = 0;

    [SerializeField] Button leftButton;
    [SerializeField] Button rightButton;


    private void OnEnable()
    {
        leftButton.onClick.AddListener(OnLeftButtonClicked);
        rightButton.onClick.AddListener(OnRightButtonClicked);
    }

    private void OnDisable()
    {
        leftButton.onClick.RemoveListener(OnLeftButtonClicked);
        rightButton.onClick.RemoveListener(OnRightButtonClicked);
    }

    private void OnLeftButtonClicked()
    {
        profiles[selectedProfileIndex].SetActive(false);
        selectedProfileIndex--;
        if (selectedProfileIndex < 0)
        {
            selectedProfileIndex = profiles.Count - 1;
        }
        profiles[selectedProfileIndex].SetActive(true);
        AudioManager.instance.PlayOneShot("page_turn");
    }

    private void OnRightButtonClicked()
    {
        profiles[selectedProfileIndex].SetActive(false);
        selectedProfileIndex++;
        if (selectedProfileIndex >= profiles.Count)
        {
            selectedProfileIndex = 0;
        }
        profiles[selectedProfileIndex].SetActive(true);
        AudioManager.instance.PlayOneShot("page_turn");
    }
}

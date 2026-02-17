using TMPro;
using UnityEngine;

public class CorkBoardUI : MonoBehaviour
{
    TextMeshProUGUI text;
    
    public string[] logs;
    int numLogs = 0;

    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        text.text = "";
        ShowComputerPasscode();
    }

    public void ShowComputerPasscode()
    {
        text.text = "";
        text.text += logs[numLogs] + "\n";
        numLogs++;
    }

    bool sPhone = false;
    public void ShowSecondPhoneNumber()
    {
        if (!sPhone)
        {
            text.text += logs[1];
            sPhone = true;
        }
    }

    bool aCode = false;
    public void ShowAudioCode()
    {
        if (!aCode)
        {
            text.text += logs[2];
            aCode = true;
        }
    }
}

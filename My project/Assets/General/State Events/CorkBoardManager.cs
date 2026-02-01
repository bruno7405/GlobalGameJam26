using TMPro;
using UnityEngine;

public class CorkBoardManager : MonoBehaviour
{
    TextMeshProUGUI text;
    
    public string[] logs;
    int numLogs = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        text.text = "";
        AddComputerPasscode();
    }

    public void AddComputerPasscode()
    {
        text.text += logs[numLogs];
        numLogs++;
    }

    bool sPhone = false;
    public void AddSecPhone()
    {
        if (!sPhone)
        {
            text.text += logs[1];
            sPhone = true;
        }
    }

    bool aCode = false;
    public void AddAudCode()
    {
        if (!aCode)
        {
            text.text += logs[2];
            aCode = true;
        }
    }
}

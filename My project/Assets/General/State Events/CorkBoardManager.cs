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
        AddText();
    }

    public void AddText()
    {
        numLogs++;
        text.text += logs[numLogs];
    }
}

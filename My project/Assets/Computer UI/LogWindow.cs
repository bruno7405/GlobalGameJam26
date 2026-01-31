using UnityEngine;
using TMPro;

public class LogWindow : MonoBehaviour
{
    public string textToDisplay;
    public TextMeshProUGUI text;

    void Start()
    {
        text.text = textToDisplay;
    }

    public void CloseWindow()
    {
        Destroy(gameObject);
    }
}

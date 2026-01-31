using UnityEngine;
using TMPro;

public class LogWindow : MonoBehaviour
{
    public string textToDisplay;
    public TextMeshProUGUI text;

    public float typeWriterSpeed = 20;
    private float charCounter = 0f;

    void Start()
    {
        text.text = textToDisplay;
        //text.maxVisibleCharacters = 0;
    }

    void Update()
    {
        charCounter += typeWriterSpeed * Time.deltaTime;
        //text.maxVisibleCharacters = Mathf.FloorToInt(charCounter);
    }

    public void CloseWindow()
    {
        Destroy(gameObject);
    }
}

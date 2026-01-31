using UnityEngine;

public class PasswordDialogue : MonoBehaviour
{
    public Canvas canvas;

    void Start()
    {
        Close();
    }

    public void Open()
    {
        gameObject.SetActive(true);
        RectTransform rt = GetComponent<RectTransform>();

        rt.anchoredPosition = new Vector2(0, 0);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}

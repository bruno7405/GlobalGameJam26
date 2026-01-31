using UnityEngine;

public class DesktopManager : MonoBehaviour
{
    public GameObject fileExplorer;

    private Canvas canvas;


    void Start()
    {
        CloseFileExplorer();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OpenFileExplorer()
    {
        fileExplorer.SetActive(true);

        RectTransform rt = fileExplorer.GetComponent<RectTransform>();

        rt.anchoredPosition = new Vector2(0, 0);
    }

    public void CloseFileExplorer()
    {
        fileExplorer.SetActive(false);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class DesktopManager : MonoBehaviour
{
    public GameObject fileExplorer;

    private Canvas canvas;

    public GameObject logWindowPrefab;

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

    public void OpenLogFile(string file)
    {
        LogWindow lw = Instantiate(logWindowPrefab).GetComponent<LogWindow>();
        lw.gameObject.SetActive(true);
        lw.gameObject.transform.SetParent(gameObject.transform);
        
        TextAsset textAsset = Resources.Load<TextAsset>(file);
        lw.textToDisplay = textAsset.text;

        RectTransform rt = lw.GetComponent<RectTransform>();
        rt.gameObject.transform.localPosition = logWindowPrefab.transform.localPosition;
        rt.gameObject.transform.localScale = logWindowPrefab.transform.localScale;
        rt.gameObject.transform.rotation = gameObject.transform.rotation;
    }
}

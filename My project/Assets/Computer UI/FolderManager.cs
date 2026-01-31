using UnityEngine;

public class FolderManager : MonoBehaviour
{
    public GameObject home, missionReports, documents;
    
    private GameObject currentFolder;

    public void Start()
    {
        home.SetActive(true);
        currentFolder = home;

        missionReports.SetActive(false);
        documents.SetActive(false);
    }

    public void OpenFolder(GameObject folder)
    {
        currentFolder.SetActive(false);
        folder.SetActive(true);
        currentFolder = folder;
    }
    
}

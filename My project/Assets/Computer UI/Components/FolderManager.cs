using UnityEngine;

public class FolderManager : MonoBehaviour
{
    public GameObject home, missionReports, documents;
    
    private GameObject currentFolder;

    public GameObject lockedAudio, openAudio;

    //public State audioState;

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

    public void UnlockFolder(string password)
    {
        if (password == "1234")
        {
            lockedAudio.SetActive(false);
            openAudio.SetActive(true);
        }
    }
    
}

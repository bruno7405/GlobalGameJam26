using UnityEngine;

public class BlackScreenUI : MonoBehaviour
{

    public GameObject root;
    [SerializeField] Animator animator;

    public static BlackScreenUI Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void FadeToBlack()
    {
        root.SetActive(true);
        animator.SetTrigger("fadeToBlack");
    }

    public void FadeToNormal()
    {
        root.SetActive(true);
        animator.SetTrigger("fadeToNormal");
    }

    public void Black()
    {
        root.SetActive(true);
        animator.SetTrigger("black");
    }

    public void Normal()
    {
        root.SetActive(true);   
        animator.SetTrigger("normal");
    }
}
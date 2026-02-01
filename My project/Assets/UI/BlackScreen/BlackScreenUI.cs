using UnityEngine;

public class BlackScreenUI : MonoBehaviour
{

    [SerializeField] GameObject root;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
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
}
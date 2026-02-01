using System;
using UnityEngine;
using UnityEngine.UI;

public class BottomChecker : MonoBehaviour
{
    public ScrollRect getRect;

    public static event Action<string> OnScrolledToBottom;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        getRect = GetComponent<ScrollRect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (getRect.verticalNormalizedPosition <= 0.1)
        {
            OnScrolledToBottom?.Invoke(gameObject.transform.parent.transform.parent.name); // D: 
            Debug.Log(gameObject.transform.parent.transform.parent.name);
        }
    }
}

using UnityEngine;
using TMPro;
using System;

public class ComputerClock : MonoBehaviour
{
    private TextMeshProUGUI text;
    private DateTime currentTime;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = DateTime.Now;
        text.text = currentTime.ToString("HH:mm");

    }
}

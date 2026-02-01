using System.Collections;
using UnityEngine;

public class PhoneManager : MonoBehaviour
{
    public bool receivingCall = false;
    public string audioDialogue;
    public float callLength;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRinger()
    {
        receivingCall = true;
        AudioManager.instance.PlayLoop("phone_ring");
    }

    public void PickUpCall()
    {
        receivingCall = false;
        AudioManager.instance.StopLoop("phone_ring");
        AudioManager.instance.PlayOneShot(audioDialogue);

        StartCoroutine(nameof(WaitForPhoneCall));

    }

    IEnumerator WaitForPhoneCall()
    {
        yield return new WaitForSeconds(callLength);
        StateMachineManager.Instance.currentState.GoToNextState();
    }
}

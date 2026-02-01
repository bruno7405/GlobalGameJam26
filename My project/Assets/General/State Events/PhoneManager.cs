using System.Collections;
using UnityEngine;

public class PhoneManager : MonoBehaviour
{
    [HideInInspector] public bool receivingCall = false;
    [HideInInspector] public string incomingCallAudio;
    [HideInInspector] public string outgoingCallAudio;
    
    [HideInInspector] public float callLength;

    public string dialAudio;
    public float dialLength;
    public string dudAudio;
    
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
        AudioManager.instance.PlayOneShot(incomingCallAudio);

        StartCoroutine(nameof(RunOutPhoneCall));
    }

    public void CallSecretary()
    {
        StartCoroutine(nameof(ICallSecretary));
    }

    IEnumerator ICallSecretary()
    {
        AudioManager.instance.PlayOneShot(dialAudio);
        yield return new WaitForSeconds(dialLength);
        AudioManager.instance.PlayOneShot(outgoingCallAudio);
        StartCoroutine(nameof(RunOutPhoneCall));
    }

    public void CallDud()
    {
        StartCoroutine(nameof(PlayDialTone));
    }

    IEnumerator PlayDialTone()
    {
        AudioManager.instance.PlayOneShot(dialAudio);
        yield return new WaitForSeconds(dialLength);
        AudioManager.instance.PlayOneShot(dudAudio);
    }

    IEnumerator RunOutPhoneCall()
    {
        yield return new WaitForSeconds(callLength);
        StateMachineManager.Instance.currentState.GoToNextState();
    }
}

using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PhoneInteractable))]
public class PhoneManager : MonoBehaviour
{
    [SerializeField] Dialogue tutorialDialogue;
    [SerializeField] Dialogue secretaryDialogue;


    [HideInInspector] public bool receivingCall = false;
    [HideInInspector] public string incomingCallAudio;
    [HideInInspector] public string outgoingCallAudio;
    
    [HideInInspector] public float callLength = 1;

    public string dialAudio;
    public float dialLength;
    public string dudAudio;

    private PhoneInteractable phoneInteractable;
    private bool phoneLock = false;

    private void Awake()
    {
        phoneInteractable = GetComponent<PhoneInteractable>();
    }

    private void OnEnable()
    {
        DialogueManager.Instance.onDialogFinished += FinishCall;
    }

    private void OnDisable()
    {
        DialogueManager.Instance.onDialogFinished -= FinishCall;
    }

    public void StartRinger()
    {
        receivingCall = true;
        AudioManager.instance.PlayLoop("phone_ring");
    }

    /// <summary>
    /// Sequence for picking up the tutorial call
    /// </summary>
    public void PickUpCallTutorial()
    {
        if (phoneLock) return;
        phoneLock = true;
        PlayerMouse.active = false; // disables input

        receivingCall = false;
        
        AudioManager.instance.StopLoop("phone_ring");
        AudioManager.instance.PlayOneShot(incomingCallAudio);

        DialogueManager.Instance.StartDialogue(tutorialDialogue);
    }

    /// <summary>
    /// Sequence for calling the secretary 1
    /// </summary>
    public void CallSecretary()
    {
        if (phoneLock) return;
        phoneLock = true;
        StartCoroutine(nameof(ICallSecretary));
    }

    IEnumerator ICallSecretary()
    {
        AudioManager.instance.PlayOneShot(dialAudio);
        yield return new WaitForSeconds(3);
        AudioManager.instance.PlayOneShot(outgoingCallAudio);
        DialogueManager.Instance.StartDialogue(secretaryDialogue);
    }

    public void PickUpCallSecretary()
    {
        if (phoneLock) return;
        phoneLock = true;
        PlayerMouse.active = false; // disables input
        receivingCall = false;
        
        AudioManager.instance.StopLoop("phone_ring");
        //AudioManager.instance.PlayOneShot(incomingCallAudio);
        DialogueManager.Instance.StartDialogue(secretaryDialogue);
    }

    public void CallDud()
    {
        if (phoneLock) return;
        phoneLock = true;
        StartCoroutine(nameof(PlayDialTone));
    }

    IEnumerator PlayDialTone()
    {
        AudioManager.instance.PlayOneShot(dialAudio);
        yield return new WaitForSeconds(dialLength);
        AudioManager.instance.PlayOneShot(dudAudio);
        phoneLock = false;
    }

    private void FinishCall()
    {
        StateMachineManager.Instance.currentState.GoToNextState();
        phoneLock = false;
        PlayerMouse.active = true; // enables input
        phoneInteractable.OnInteractExit();
    }
}

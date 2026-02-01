using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class GunInteractable : MonoBehaviour, IInteractable
{
    Vector3 originalPos;
    Quaternion originalRotation;
    [SerializeField] Transform handTransform;

    [SerializeField] Dialogue gunCheckDialog;

    private void Start()
    {
        originalPos = transform.position;
        originalRotation = transform.rotation;
    }


    public void OnInteract()
    {
        if (StateMachineManager.Instance.currentState.GetType() == typeof(GunCheckState)) StartCoroutine(GunCheckSequence());
        else if (StateMachineManager.Instance.currentState.GetType() == typeof(GunCheckTwoState)) StartCoroutine(GunCheckSequence2());

        StartCoroutine(MoveTo(handTransform.position, handTransform.rotation, 0.5f));
    }

    public void OnInteractExit()
    {
        StopAllCoroutines();
        PlayerMouse.interacting = false;
        StartCoroutine(MoveTo(originalPos, originalRotation, 0.5f));
    }

    IEnumerator GunCheckSequence()
    {
        Debug.Log("gun check 1");
        DialogueManager.Instance.StartDialogue(gunCheckDialog);
        yield return new WaitForSeconds(10);
        Debug.Log("boo");
        StateMachineManager.Instance.currentState.GoToNextState();
    }

    IEnumerator GunCheckSequence2()
    {
        Debug.Log("gun check 2");
        yield return new WaitForSeconds(1);
        StateMachineManager.Instance.currentState.GoToNextState();
    }

    IEnumerator MoveTo(Vector3 targetPosition, Quaternion targetRotation, float duration)
    {
        Vector3 startPos = transform.position;
        Quaternion startRot = transform.rotation;
        float time = 0;

        while (time < 1)
        {
            transform.position = Vector3.Lerp(startPos, targetPosition, time);
            transform.rotation = Quaternion.Lerp(startRot, targetRotation, time);
            time += Time.deltaTime / duration;
            yield return null; // Waits for the next frame
        }

        // Ensure exact final position and rotation
        transform.position = targetPosition;
        transform.rotation = targetRotation;
    }
}

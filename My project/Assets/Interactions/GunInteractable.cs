using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class GunInteractable : MonoBehaviour, IInteractable
{
    Vector3 originalPos;
    Quaternion originalRotation;
    [SerializeField] Transform handTransform;

    private void Start()
    {
        originalPos = transform.position;
        originalRotation = transform.rotation;
    }

    public void OnInteract()
    {
        if (StateMachineManager.Instance.currentState.GetType() == typeof(GunCheckState))
        {
            StateMachineManager.Instance.currentState.GoToNextState();
        }

        StartCoroutine(MoveTo(handTransform.position, handTransform.rotation, 0.5f));
    }

    public void OnInteractExit()
    {
        StopAllCoroutines();
        StartCoroutine(MoveTo(originalPos, originalRotation, 0.5f));
        PlayerMouse.interacting = false;
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

using UnityEngine;

public class Spinning : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 50f;

    [SerializeField] Vector3 axis;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(axis * rotationSpeed * Time.deltaTime);
    }
}

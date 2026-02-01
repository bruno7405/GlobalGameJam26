using UnityEngine;

public class PhoneRinger : MonoBehaviour
{
    public void StartRinger()
    {
        AudioManager.instance.PlayOneShot("phone_ring");
    }
}

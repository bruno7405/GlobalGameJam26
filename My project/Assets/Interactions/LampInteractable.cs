using UnityEngine;

public class LampInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private Light lampLight;
    [SerializeField] private Renderer bulbRenderer;
    private Material bulbMaterial;
    [SerializeField] private Color lightBulbColor;

    private bool isOn = false;

    private void Awake()
    {
        bulbMaterial = bulbRenderer.material;
    }

    public void OnInteract()
    {
        Debug.Log("Interacted with Lamp");
        if (isOn) // Turn off the lamp
        {
            lampLight.enabled = false;
            bulbMaterial.DisableKeyword("_EMISSION");
            isOn = false;
        }
        else // Turn on the lamp
        {
            lampLight.enabled = true;
            //We need to enable the EMISSION
            bulbMaterial.EnableKeyword("_EMISSION");
            //before we can set the color
            bulbMaterial.SetColor("_EmissionColor", lightBulbColor * 2);
            isOn = true;
        }

        OnInteractExit();
    }

    public void OnInteractExit()
    {
        PlayerMouse.interacting = false;
    }
}

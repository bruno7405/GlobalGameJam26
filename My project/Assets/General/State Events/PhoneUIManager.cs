using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhoneUIManager : MonoBehaviour
{
    public string secretaryPhoneNumber = "1234456767";
    public PhoneManager phoneManager;
    public TMP_InputField inputField;
    
    public void AttemptCall()
    {
        string numbers = inputField.text.Trim();

        Debug.Log(numbers);
        
        if (numbers == secretaryPhoneNumber && StateMachineManager.Instance.currentState.GetType() == typeof(IntroState))
        {
            phoneManager.CallSecretary();
        } 
        else if (numbers == "3564")
        {
            AudioManager.instance.PlayOneShot("debug_call"); // easter egg
        } 
        else
        {
            phoneManager.CallDud();
        }
    }
}

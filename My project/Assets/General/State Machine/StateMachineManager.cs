using UnityEngine;

public class StateMachineManager : MonoBehaviour
{
    public static StateMachineManager Instance;
    public State tutorialState;
    public State currentState;


    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            currentState = tutorialState;
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (currentState != null)
        {
            currentState.OnStart();
        }
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnUpdate();
        }
    }

    public void SetNewState(State state)
    {
        if (state != null)
        {
            currentState = state;
            currentState.OnStart();
        }
    }
}
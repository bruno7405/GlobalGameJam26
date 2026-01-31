using UnityEngine;

public class StateMachineManager : MonoBehaviour
{
    public StateMachineManager Instance;
    public State currentState;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
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
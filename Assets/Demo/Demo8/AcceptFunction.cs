using UnityEngine;

public class AcceptFunction : MonoBehaviour, Y9g.IButtonClick
{
    private event System.Action acceptFunction;

    public void Execute()
    {
        acceptFunction?.Invoke();
    }

    public void RegisterAcceptFunction(System.Action acceptFunction)
    {
        this.acceptFunction += acceptFunction;
    }
}
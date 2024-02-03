using UnityEngine;

public class CancelFunction : MonoBehaviour, Y9g.IButtonClick
{
    private event System.Action cancelFunction;

    public void Execute()
    {
        cancelFunction?.Invoke();
    }

    public void RegisterCancelFunction(System.Action cancelFunction)
    {
        this.cancelFunction += cancelFunction;
    }
}
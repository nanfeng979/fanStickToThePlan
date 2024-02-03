using UnityEngine;
using Y9g;

public class CancelClick : MonoBehaviour, IButtonClick
{
    public void Execute()
    {
        gameObject.SetActive(false);
    }
}
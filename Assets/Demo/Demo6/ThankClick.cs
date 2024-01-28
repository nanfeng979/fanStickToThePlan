using UnityEngine;

public class ThankClick : MonoBehaviour, Y9g.IButtonClick
{
    public void Execute()
    {
        Debug.Log("Thank you for playing!");
    }
}
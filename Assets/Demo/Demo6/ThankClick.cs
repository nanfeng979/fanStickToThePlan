using UnityEngine;

public class ThankClick : MonoBehaviour, Y9g.IButtonClick
{
    public void OnButtonClick()
    {
        Debug.Log("Thank you for playing!");
    }
}
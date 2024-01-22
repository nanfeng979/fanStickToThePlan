using UnityEngine;

public class ThankClick : MonoBehaviour, IButtonClick
{
    public void OnButtonClick()
    {
        Debug.Log("Thank you for playing!");
    }
}
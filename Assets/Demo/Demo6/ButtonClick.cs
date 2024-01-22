using UnityEngine;

public class ButtonClick : MonoBehaviour, IButtonClick
{
    public GameObject nextUIList;

    public void OnButtonClick()
    {
        if (nextUIList != null)
        {
            nextUIList.SetActive(true);
        }
    }
}
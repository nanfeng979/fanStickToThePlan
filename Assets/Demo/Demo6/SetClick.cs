using UnityEngine;

public class SetClick : MonoBehaviour, IButtonClick
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
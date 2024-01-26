using UnityEngine;

public class SetClick : MonoBehaviour, Y9g.IButtonClick
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
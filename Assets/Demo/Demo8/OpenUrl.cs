using UnityEngine;

public class OpenUrl : MonoBehaviour, Y9g.IButtonClick
{
    [SerializeField]
    private string urlLink = "https://www.baidu.com";
    
    public void Execute()
    {
        Application.OpenURL(urlLink);
    }
}
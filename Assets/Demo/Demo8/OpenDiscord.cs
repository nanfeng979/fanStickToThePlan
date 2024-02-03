using UnityEngine;

public class OpenDiscord : MonoBehaviour, Y9g.IButtonClick
{
    [SerializeField]
    private GameObject confirmToOpenDiscord;
    
    public void Execute()
    {
        confirmToOpenDiscord.SetActive(true);
    }
}
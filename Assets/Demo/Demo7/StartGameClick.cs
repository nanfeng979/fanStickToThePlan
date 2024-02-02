using UnityEngine;

public class StartGameClick : MonoBehaviour, Y9g.IButtonClick, Y9g.ISpace
{
    [SerializeField]
    private GameObject levelSelect;

    public void Execute()
    {
        levelSelect.SetActive(true);
    }
}
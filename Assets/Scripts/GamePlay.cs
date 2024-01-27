using UnityEngine;
using Y9g;

public class GamePlay : Page, IEscClick
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject gamePlayUI;

    public override void OnMove(Move4Direction direction)
    {
        player.GetComponent<IMove>().OnMove(direction);
    }

    public override GameObject GetCurrentObject()
    {
        return player;
    }

    public void OnEsc()
    {
        gamePlayUI.SetActive(true);
    }
}
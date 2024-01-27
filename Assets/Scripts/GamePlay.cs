using UnityEngine;
using Y9g;

public class GamePlay : Page
{
    [SerializeField]
    private GameObject player;

    public override void OnMove(Move4Direction direction)
    {
        player.GetComponent<IMove>().OnMove(direction);
    }

    public override GameObject GetCurrentObject()
    {
        return player;
    }
}
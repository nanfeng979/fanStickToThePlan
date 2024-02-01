using UnityEngine;
using Y9g;

public class GamePlay : Page, IMove, IEscClick
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject gamePlayUI;

    void Start() {
        // 注册事件。
        AddCurrentPageAllAction(InOnMoveDown);
        AddCurrentPageAllAction(InputManager.Instance.OutOnEscDown);
    }

    public void OnMove(Move4Direction direction)
    {
        player.GetComponent<IMove>().OnMove(direction);
    }

    public override GameObject GetCurrentObject()
    {
        return player;
    }

    public void Execute()
    {
        gamePlayUI.SetActive(true);
    }

    public void ChangePlayer(GameObject player)
    {
        this.player = player;
    }

    private void InOnMove()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            OnMove(Move4Direction.Up);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            OnMove(Move4Direction.Down);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            OnMove(Move4Direction.Left);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            OnMove(Move4Direction.Right);
        }
    }

    private void InOnMoveDown()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            player.GetComponent<IMoveDown>().OnMoveDown(Move4Direction.Up);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            player.GetComponent<IMoveDown>().OnMoveDown(Move4Direction.Down);
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            player.GetComponent<IMoveDown>().OnMoveDown(Move4Direction.Left);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            player.GetComponent<IMoveDown>().OnMoveDown(Move4Direction.Right);
        }
    }
}
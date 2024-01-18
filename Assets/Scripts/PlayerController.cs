using UnityEngine;
using Y9g;

public class PlayerController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Move(Move4Direction.Up);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Move(Move4Direction.Down);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Move(Move4Direction.Left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Move(Move4Direction.Right);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            MapManager.Instance.PrintPlayerCurrentIndex();
        }
    }

    private void Move(Move4Direction moveDirection)
    {
        if (!MapManager.Instance.IsCanMove(moveDirection))
        {
            Debug.Log("不能移动");
            return;
        }

        // 根据移动方向，修改玩家所对应的索引值。
        switch (moveDirection)
        {
            case Move4Direction.Up:
                MapManager.Instance.AddPlayerIndex(-MapManager.Instance.mapXCount);
                break;
            case Move4Direction.Down:
                MapManager.Instance.AddPlayerIndex(MapManager.Instance.mapXCount);
                break;
            case Move4Direction.Left:
                MapManager.Instance.AddPlayerIndex(-1);
                break;
            case Move4Direction.Right:
                MapManager.Instance.AddPlayerIndex(1);
                break;
        }

        // 根据玩家索引值，获取玩家的位置，并修改玩家的位置。
        transform.position = MapManager.Instance.GetPlayerPosition();
    }
}
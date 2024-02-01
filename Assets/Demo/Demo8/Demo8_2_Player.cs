using System.Collections.Generic;
using UnityEngine;
using Y9g;

/// <summary>
/// Player Controller
/// </summary>
public class Demo8_2_Player : MonoBehaviour, IMoveDown
{
    private List<List<int>> mapIndexList;
    private Vector2Int playerIndex;

    public void OnMoveDown(Move4Direction direction)
    {
        switch (direction)
        {
            case Move4Direction.Up:
                if (!Utils.IsCrossTheBorderBy2DArray(ref mapIndexList, playerIndex, (int)Move4Direction.Up - 1))
                {
                    Debug.Log("Up can move");
                    ChangePlayerIndex(new Vector2Int(playerIndex.x - 1, playerIndex.y));
                    ChangePlayerPosition();
                }
                break;
            case Move4Direction.Down:
                if (!Utils.IsCrossTheBorderBy2DArray(ref mapIndexList, playerIndex, (int)Move4Direction.Down - 1))
                {
                    Debug.Log("Down can move");
                    ChangePlayerIndex(new Vector2Int(playerIndex.x + 1, playerIndex.y));
                    ChangePlayerPosition();
                }
                break;
            case Move4Direction.Left:
                if (!Utils.IsCrossTheBorderBy2DArray(ref mapIndexList, playerIndex, (int)Move4Direction.Left - 1))
                {
                    Debug.Log("Left can move");
                    ChangePlayerIndex(new Vector2Int(playerIndex.x, playerIndex.y - 1));
                    ChangePlayerPosition();
                }
                break;
            case Move4Direction.Right:
                if (!Utils.IsCrossTheBorderBy2DArray(ref mapIndexList, playerIndex, (int)Move4Direction.Right - 1))
                {
                    Debug.Log("Right can move");
                    ChangePlayerIndex(new Vector2Int(playerIndex.x, playerIndex.y + 1));
                    ChangePlayerPosition();
                }
                break;
        }
    }
    
    public void SetMapIndexList(List<List<int>> mapIndexList)
    {
        this.mapIndexList = mapIndexList;
        MapModel.Instance.SetMapIndexList(mapIndexList);
    }

    public void SetPlayerIndex(Vector2Int playerIndex)
    {
        this.playerIndex = playerIndex;
        MapModel.Instance.SetPlayerIndex(playerIndex);
    }

    private void ChangePlayerIndex(Vector2Int playerIndex)
    {
        this.playerIndex = playerIndex;
        MapModel.Instance.SetPlayerIndex(playerIndex);
    }

    private void ChangePlayerPosition()
    {
        transform.position = MapModel.Instance.GetPlayerPosition();
        transform.position = UsualCalculate.Vector3ChangeY(transform.position, 1.5f);
    }
}
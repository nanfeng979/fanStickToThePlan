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
    private List<int> canMoveList = new List<int> { 1 };
    private List<int> obstacleList = new List<int> { 2 };
    private List<List<int>> obstacleIndexList;
    private Vector2Int endIndex;


    public void OnMoveDown(Move4Direction direction)
    {
        switch (direction)
        {
            case Move4Direction.Up:
                if (Utils.IsCrossTheBorderBy2DArray(ref mapIndexList, playerIndex, (int)Move4Direction.Up - 1))
                {
                    break;
                }
                if (Utils.IsCrossContainsList(ref mapIndexList, playerIndex, (int)Move4Direction.Up - 1, canMoveList))
                {
                    if (!Utils.IsCrossContainsList(ref obstacleIndexList, playerIndex, (int)Move4Direction.Up - 1, obstacleList))
                    {
                        ChangePlayerIndex(new Vector2Int(playerIndex.x - 1, playerIndex.y));
                        ChangePlayerPosition();
                    }
                }
                break;
            case Move4Direction.Down:
                if (Utils.IsCrossTheBorderBy2DArray(ref mapIndexList, playerIndex, (int)Move4Direction.Down - 1))
                {
                    break;
                }
                if (Utils.IsCrossContainsList(ref mapIndexList, playerIndex, (int)Move4Direction.Down - 1, canMoveList))
                {
                    if (!Utils.IsCrossContainsList(ref obstacleIndexList, playerIndex, (int)Move4Direction.Down - 1, obstacleList))
                    {
                        ChangePlayerIndex(new Vector2Int(playerIndex.x + 1, playerIndex.y));
                        ChangePlayerPosition();
                    }
                }
                break;
            case Move4Direction.Left:
                if (Utils.IsCrossTheBorderBy2DArray(ref mapIndexList, playerIndex, (int)Move4Direction.Left - 1))
                {
                    break;
                }
                if (Utils.IsCrossContainsList(ref mapIndexList, playerIndex, (int)Move4Direction.Left - 1, canMoveList))
                {
                    if (!Utils.IsCrossContainsList(ref obstacleIndexList, playerIndex, (int)Move4Direction.Left - 1, obstacleList))
                    {
                        ChangePlayerIndex(new Vector2Int(playerIndex.x, playerIndex.y - 1));
                        ChangePlayerPosition();
                    }
                }
                break;
            case Move4Direction.Right:
                if (Utils.IsCrossTheBorderBy2DArray(ref mapIndexList, playerIndex, (int)Move4Direction.Right - 1))
                {
                    break;
                }
                if (Utils.IsCrossContainsList(ref mapIndexList, playerIndex, (int)Move4Direction.Right - 1, canMoveList))
                {
                    if (!Utils.IsCrossContainsList(ref obstacleIndexList, playerIndex, (int)Move4Direction.Right - 1, obstacleList))
                    {
                        ChangePlayerIndex(new Vector2Int(playerIndex.x, playerIndex.y + 1));
                        ChangePlayerPosition();
                    }
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
        CheckEnd();
    }

    private void ChangePlayerIndex(Vector2Int playerIndex)
    {
        this.playerIndex = playerIndex;
        MapModel.Instance.SetPlayerIndex(playerIndex);
        CheckEnd();
    }

    private void CheckEnd()
    {
        if (playerIndex == endIndex)
        {
            Debug.Log("You Win!");
        }
    }

    private void ChangePlayerPosition()
    {
        transform.position = MapModel.Instance.GetPlayerPosition();
        transform.position = UsualCalculate.Vector3ChangeY(transform.position, 1.5f);
    }

    public void SetObstacleIndexList(List<List<int>> obstacleIndexList)
    {
        this.obstacleIndexList = obstacleIndexList;
    }

    public void SetEndIndex(Vector2Int endIndex)
    {
        this.endIndex = endIndex;
    }

}
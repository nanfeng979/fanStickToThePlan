using System.Collections.Generic;
using UnityEngine;
using Y9g;

public class MapManager : Singleton<MapManager>
{
    #region 地图相关
    [HideInInspector]
    public int mapXCount;
    [HideInInspector]
    public int mapZCount;
    [HideInInspector]
    public int[] mapIndex;
    [HideInInspector]
    public GameObject mapList;
    private HashSet<int> Obstacles = new HashSet<int>() { 1, 2 };
    #endregion 地图相关
    
    [HideInInspector]
    public int playerIndex;

    internal void SetPlayerIndex(int value)
    {
        playerIndex = value;
    }

    internal void AddPlayerIndex(int addValue)
    {
        playerIndex += addValue;
    }

    internal int GetPlayerInMapIndex()
    {
        return mapIndex[playerIndex];
    }

    internal Vector3 GetPlayerPosition()
    {
        return mapList.transform.GetChild(playerIndex).position + new Vector3(0, 1.5f, 0);
    }

    internal bool IsCanMove(Move4Direction moveDirection)
    {
        switch (moveDirection)
        {
            case Move4Direction.Up:
                // 如果玩家在第一排以及按下上移键，则不能移动。
                if (playerIndex < mapXCount)
                {
                    return false;
                }
                // 如果下一个位置是障碍物，则不能移动。
                if (Obstacles.Contains(mapIndex[playerIndex - mapXCount]))
                {
                    return false;
                }
                break;

            case Move4Direction.Down:
                // 如果玩家在最后一排以及按下下移键，则不能移动。
                if (playerIndex >= mapIndex.Length - mapXCount)
                {
                    return false;
                }
                // 如果下一个位置是障碍物，则不能移动。
                if (Obstacles.Contains(mapIndex[playerIndex + mapXCount]))
                {
                    return false;
                }
                break;

            case Move4Direction.Left:
                // 如果玩家在最左边以及按下左移键，则不能移动。
                if (playerIndex % mapXCount == 0)
                {
                    return false;
                }
                // 如果下一个位置是障碍物，则不能移动。
                if (Obstacles.Contains(mapIndex[playerIndex - 1]))
                {
                    return false;
                }
                break;

            case Move4Direction.Right:
                // 如果玩家在最右边以及按下右移键，则不能移动。
                if (playerIndex % mapXCount == mapXCount - 1)
                {
                    return false;
                }
                // 如果下一个位置是障碍物，则不能移动。
                if (Obstacles.Contains(mapIndex[playerIndex + 1]))
                {
                    return false;
                }
                break;
        }

        return true;
    }

    internal void PrintPlayerCurrentIndex()
    {
        Debug.Log("当前玩家所在的位置是：" + playerIndex);
    }
}
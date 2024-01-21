using System.Collections.Generic;
using UnityEngine;
using Y9g;

public class MapManager : Singleton<MapManager>
{
    #region 地图相关
    private int mapXCount;
    public int MapXCount
    {
        get
        {
            return mapXCount;
        }
        set
        {
            mapXCount = value;
        }
    }
    private int mapZCount;
    public int MapZCount
    {
        get
        {
            return mapZCount;
        }
        set
        {
            mapZCount = value;
        }
    }
    private int[] mapIndex;
    public int[] MapIndex
    {
        get
        {
            return mapIndex;
        }
        set
        {
            mapIndex = value;
        }
    }
    private GameObject mapList;
    public GameObject MapList
    {
        get
        {
            return mapList;
        }
        set
        {
            mapList = value;
        }
    }
    private List<int> obstacles = new List<int>();
    public List<int> Obstacles
    {
        get
        {
            return obstacles;
        }
        set
        {
            obstacles = value;
        }
    }
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

    internal void SetBaseInfo(int mapXCount, int mapZCount, int[] mapIndex, GameObject mapList, List<int> obstacles = null)
    {
        this.mapXCount = mapXCount;
        this.mapZCount = mapZCount;
        this.mapIndex = mapIndex;
        this.mapList = mapList;
        this.obstacles = obstacles;
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

    internal bool IsObstacle(int index)
    {
        return obstacles.Contains(mapIndex[index]);
    }

    internal void PrintPlayerCurrentIndex()
    {
        Debug.Log("当前玩家所在的位置是：" + playerIndex);
    }
}
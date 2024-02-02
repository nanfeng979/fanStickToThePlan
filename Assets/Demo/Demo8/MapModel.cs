using System.Collections.Generic;
using UnityEngine;
using Y9g;

public class MapModel : Singleton_sub<MapModel>
{
    private List<List<int>> mapIndexList;
    private Vector2Int playerIndex;

    public List<List<int>> GetMapIndexList()
    {
        return mapIndexList;
    }

    public void SetMapIndexList(List<List<int>> mapIndexList)
    {
        this.mapIndexList = mapIndexList;
    }

    public Vector2Int GetPlayerIndex()
    {
        return playerIndex;
    }

    public void SetPlayerIndex(Vector2Int playerIndex)
    {
        this.playerIndex = playerIndex;
    }

    public Vector3 GetPlayerPosition()
    {
        return transform.GetChild(0).GetChild(mapIndexList[0].Count * (playerIndex.x - 1) + playerIndex.y - 1).transform.position;
    }
}
using System.Collections.Generic;
using UnityEngine;
using Y9g;

public class MapModel : Singleton<MapModel>
{
    private List<List<int>> mapIndexList;
    private Vector2Int playerIndex;

    public List<List<int>> GetMapIndexList()
    {
        return mapIndexList;
    }

    public Vector2Int GetPlayerIndex()
    {
        return playerIndex;
    }

}
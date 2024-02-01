using System.Collections.Generic;
using UnityEngine;

public class Demo8 : MapGenerate2
{
    protected override void InitMapIndex()
    {
        mapIndex = new List<List<int>>() {
            new List<int>() { 0, 0, 0, 0, 0, 0, 1, 1 },
            new List<int>() { 0, 0, 0, 1, 1, 1, 1, 0 },
            new List<int>() { 0, 0, 1, 1, 0, 0, 0, 0 },
            new List<int>() { 0, 1, 1, 0, 0, 0, 0, 0 },
            new List<int>() { 1, 1, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 1, 0, 0, 0, 0, 0, 0, 0 }
        };

        playerIndex = new Vector2Int(6, 8);
    }
}
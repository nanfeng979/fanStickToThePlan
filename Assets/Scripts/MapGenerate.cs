using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MapGenerate : MonoBehaviour
{
    #region 地图相关
    public List<GameObject> mapBlocks;
    const int mapXCount = 8;
    const int mapZCount = 6;
    private int[] mapIndex = new int[mapXCount * mapZCount];
    
    #endregion

    #region 玩家相关
    public GameObject playerPrefab;
    #endregion

    protected virtual void Start()
    {
        
    }

    void Update()
    {
        
    }
}

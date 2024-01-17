using System.Collections.Generic;
using UnityEngine;

public class Demo3 : MonoBehaviour
{
    #region 地图相关
    public List<GameObject> mapBlocks;
    const int mapXCount = 10;
    const int mapZCount = 10;
    private int[] mapIndex = new int[mapXCount * mapZCount];
    #endregion

    #region 玩家相关
    public GameObject player;
    #endregion

    void Start()
    {
        // 为mapIndex数组赋值
        for (int i = 0; i < mapIndex.Length; i++)
        {
            mapIndex[i] = UnityEngine.Random.Range(0, mapBlocks.Count);
        }

        Y9g.MapGenerate.GenerateVariousMap(mapXCount, mapZCount, mapBlocks, mapIndex, 0.5f, true);
    }

    void Update()
    {
        
    }
}
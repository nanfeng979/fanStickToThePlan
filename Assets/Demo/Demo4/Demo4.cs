using System.Collections.Generic;
using UnityEngine;

public class Demo4 : MonoBehaviour
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

    void Start()
    {
        mapIndex = new int[]
        {
            2, 2, 0, 0, 0, 0, 
            0, 2, 2, 0, 0, 0, 
            0, 0, 2, 2, 0, 0, 
            0, 0, 0, 2, 2, 0,
            0, 0, 0, 0, 2, 0, 
            0, 0, 0, 0, 2, 0, 
            0, 0, 0, 0, 2, 2, 
            0, 0, 0, 0, 0, 2,
        };

        GameObject mapList =  Y9g.MapGenerate.GenerateVariousMap(mapXCount, mapZCount, mapBlocks, mapIndex, 0.5f, true);

        GameObject player = Instantiate(playerPrefab, mapList.transform.GetChild(0).position, Quaternion.identity);
        player.transform.position = Y9g.UsualCalculate.Vector3ChangeY(player.transform.position, 1.5f);
    }

    void Update()
    {
        
    }
}
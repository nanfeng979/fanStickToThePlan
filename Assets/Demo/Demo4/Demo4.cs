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
        mapIndex = Y9g.SystemIO.ReadJsonFileFromStreamingAssets<int[]>("Demo4");

        MapManager.Instance.mapIndex = mapIndex;
        MapManager.Instance.mapXCount = mapXCount;
        MapManager.Instance.mapZCount = mapZCount;

        GameObject mapList =  Y9g.MapGenerate.GenerateVariousMap(mapXCount, mapZCount, mapBlocks, mapIndex, 0.2f, true);
        MapManager.Instance.mapList = mapList;

        // 创建玩家。
        GameObject player = Instantiate(playerPrefab, mapList.transform.GetChild(0).position, Quaternion.identity);
        player.transform.position = Y9g.UsualCalculate.Vector3ChangeY(player.transform.position, 1.5f);
        player.AddComponent<PlayerController>();

        MapManager.Instance.SetPlayerIndex(0);
    }
}
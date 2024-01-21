using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class MapGenerate : MonoBehaviour
{
    #region 地图相关
    private List<GameObject> mapBlocks = new List<GameObject>();
    private int mapXCount;
    private int mapZCount;
    private int[] mapIndex;
    public string mapFileName;
    #region 障碍物相关
    [SerializeField]
    private List<GameObject> obstacles;
    private List<int> obstaclesIndex = new List<int>();
    private List<float> obstaclesYOffSet = new List<float>();
    #endregion 障碍物相关
    #endregion 地图相关

    #region 玩家相关
    public GameObject playerPrefab;
    #endregion

    protected virtual void Start()
    {
        // 读取并初始化数据。
        if (string.IsNullOrEmpty(mapFileName))
        {
            Debug.LogError("mapFileName 不能为空");
            return;
        }
        MapGenerateData mapGenerateData = Y9g.SystemIO.ReadJsonFromStreamingAssets<MapGenerateData>(mapFileName);
        Init(mapGenerateData);

        // 创建地图。
        GameObject mapList = Y9g.MapGenerate.GenerateVariousMap(mapXCount, mapZCount, mapBlocks, mapIndex, 0.2f, true);

        // 绑定地图。
        MapManager.Instance.SetBaseInfo(mapXCount, mapZCount, mapIndex, mapList, obstaclesIndex);

        // 创建障碍物。
        // 遍历maplist
        for (int i = 0; i < mapList.transform.childCount; i++)
        {
            // 如果是障碍物。
            if (MapManager.Instance.IsObstacle(i))
            {
                // 创建障碍物。
                GameObject obstacle = Instantiate(obstacles[mapIndex[i]], mapList.transform.GetChild(i).position, Quaternion.identity, mapList.transform.GetChild(i));
                obstacle.transform.position = Y9g.UsualCalculate.Vector3ChangeY(obstacle.transform.position, obstaclesYOffSet[mapIndex[i] - 1]);
            }
        }

        // 调整障碍物位置。

        // 创建玩家。
        GameObject player = Instantiate(playerPrefab, mapList.transform.GetChild(0).position, Quaternion.identity);
        player.transform.position = Y9g.UsualCalculate.Vector3ChangeY(player.transform.position, 1.5f);
        player.AddComponent<PlayerController>();

        // 绑定玩家。
        MapManager.Instance.SetPlayerIndex(0);
    }

    private void Init(MapGenerateData mapGenerate)
    {
        this.mapXCount = mapGenerate.mapXCount;
        this.mapZCount = mapGenerate.mapZCount;
        this.mapIndex = mapGenerate.mapIndex;
        for (int i = 0; i < mapGenerate.mapBlocks.Count; i++)
        {
            this.mapBlocks.Add(Resources.Load<GameObject>(mapGenerate.mapBlocks[i]));
        }
        for (int i = 0; i < mapGenerate.obstaclesInfo.Count; i++)
        {
            this.obstaclesIndex.Add(mapGenerate.obstaclesInfo[i].index);
            this.obstaclesYOffSet.Add(mapGenerate.obstaclesInfo[i].yOffSet);
        }
    }
    
}

[Serializable]
public class MapGenerateData
{
    public int mapXCount;
    public int mapZCount;
    public int[] mapIndex;
    public List<string> mapBlocks;
    public List<ObstacleInfo> obstaclesInfo;
}

[Serializable]
public class ObstacleInfo
{
    public int index;
    public float yOffSet;
}
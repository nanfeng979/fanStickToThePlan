using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MapGenerate2 : MonoBehaviour
{
    #region 地图相关
    protected List<List<int>> mapIndex;
    [SerializeField]
    private List<GameObject> mapBlocks;
    protected List<List<int>> obstacleIndexList;
    protected Vector2Int endIndex;
    #endregion 地图相关

    #region 玩家相关
    [SerializeField]
    private GameObject playerPrefab;
    protected Vector2Int playerIndex;
    #endregion 玩家相关

    void Start()
    {
        InitMapIndex();

        // 生成地图。
        GameObject mapList = Y9g.MapGenerate.GenerateVariousMap(mapIndex, mapBlocks, 1.0f);
        mapList.transform.parent = transform;

        // 生成玩家。
        Vector3 playerPosition = mapList.transform.GetChild(mapIndex[0].Count * (playerIndex.x - 1) + playerIndex.y - 1).transform.position;
        GameObject player = Instantiate(playerPrefab, playerPosition, Quaternion.identity, transform.parent);
        player.transform.position = Y9g.UsualCalculate.Vector3ChangeY(playerPosition, 1.5f);
        player.AddComponent<Demo8_2_Player>();

        // 绑定玩家。
        transform.parent.GetComponent<GamePlay>().ChangePlayer(player);

        // 同步数据。
        player.GetComponent<Demo8_2_Player>().SetMapIndexList(mapIndex);
        player.GetComponent<Demo8_2_Player>().SetPlayerIndex(playerIndex);
        player.GetComponent<Demo8_2_Player>().SetObstacleIndexList(obstacleIndexList);
        player.GetComponent<Demo8_2_Player>().SetEndIndex(endIndex);
        MapModel.Instance.SetMapIndexList(mapIndex);
        MapModel.Instance.SetPlayerIndex(playerIndex);
    }

    protected virtual void InitMapIndex()
    {
        mapIndex = new List<List<int>>() {
            new List<int>() { 0, 0, 0, 0, 0, 0, 1, 1 },
            new List<int>() { 0, 0, 0, 1, 1, 1, 1, 0 },
            new List<int>() { 0, 0, 1, 1, 0, 0, 0, 0 },
            new List<int>() { 0, 1, 1, 0, 0, 0, 0, 0 },
            new List<int>() { 1, 1, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 1, 0, 0, 0, 0, 0, 0, 0 }
        };

        playerIndex = new Vector2Int(6, 1);
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;
using Y9g;

public class Demo5 : MonoBehaviour
{
    [SerializeField]
    private GameObject UIGameobjectList;

    private Dictionary<int, GameObject> UIMapping = new Dictionary<int, GameObject>();
    private int previousUIIndex = 0;
    private int currentUIIndex = 0;

    public string buttonColor;

    const int Up = (int)Move4Direction.Up;
    const int Down = (int)Move4Direction.Down;
    const int Left = (int)Move4Direction.Left;
    const int Right = (int)Move4Direction.Right;

    int[][] UIGraph = new int[][]
    {
        new int[]{0, Right, Down, 0,  0, 0, 0, 0,  0, 0, 0, 0},
        new int[]{Left, 0, 0, Down,  0, 0, 0, 0,  0, 0, 0, Right},
        new int[]{Up, 0, 0, Right,  Down, 0, 0, 0,  0, 0, 0, 0},
        new int[]{0, Up, Left, 0,  0, Down, 0, 0,  0, 0, 0, Right},

        new int[]{0, 0, Up, 0,  0, Right, 0, Down,  0, 0, 0, 0},
        new int[]{0, 0, 0, Up,  Left, 0, 0, 0,  Down, 0, 0, Right},
        new int[]{0, 0, 0, 0,  Up, 0, 0, Right,  0, Down, 0, 0},
        new int[]{0, 0, 0, 0,  Up, 0, Left, 0,  Right, Down, 0, 0},

        new int[]{0, 0, 0, 0,  0, Up, 0, Left,  0, 0, Down, Right},
        new int[]{0, 0, 0, 0,  0, 0, 0, Up,  0, 0, Right, 0},
        new int[]{0, 0, 0, 0,  0, 0, 0, 0,  Up, Left, 0, Right},
        new int[]{0, 0, 0, Left,  0, 0, Down, 0,  0, 0, 0, 0},
    };

    void Start()
    {
        // 初始化UI映射。
        for (int i = 0; i < UIGameobjectList.transform.childCount; i++)
        {
            UIMapping.Add(i, UIGameobjectList.transform.GetChild(i).gameObject);
        }

        // 初始化UI颜色。
        ChangeUIColor(currentUIIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveInput(Move4Direction.Up);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveInput(Move4Direction.Down);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveInput(Move4Direction.Left);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveInput(Move4Direction.Right);
        }
    }

    // 选择UI。
    private void ChoseUI(int index)
    {
        ChangeUIIndex(index);
        ChangeUIColor(index);
        PlaySound(0);
    }

    // 改变UI索引。
    private void ChangeUIIndex(int index)
    {
        previousUIIndex = currentUIIndex; // 改变上一个UI索引。
        currentUIIndex = index; // 改变当前UI索引。
    }

    // 改变UI颜色。
    private void ChangeUIColor(int index)
    {
        // 改变上一个UI颜色。
        GameObject previousUI = UIMapping[previousUIIndex];
        previousUI.transform.GetComponent<UnityEngine.UI.Button>().image.color = Y9g.Utils.HexToColor("#FFFFFF");

        // 改变当前UI颜色。
        GameObject currentUI = UIMapping[index];
        currentUI.transform.GetComponent<UnityEngine.UI.Button>().image.color = Y9g.Utils.HexToColor("#" + buttonColor);
    }

    // 播放音效。
    private void PlaySound(int index)
    {
        SoundManager.Instance.PlaySound(index);
    }

    // 获取下一个UI索引。
    private int GetNextUIIndex(int direction)
    {
        return Array.IndexOf(GetCurrentUIMapping(), direction);
    }

    // 获取当前UI映射。
    private int[] GetCurrentUIMapping()
    {
        return UIGraph[GetUIIndex()];
    }

    // 获取当前UI索引。
    private int GetUIIndex()
    {
        return currentUIIndex;
    }

    // 移动输入。
    private void MoveInput(Move4Direction moveDirection)
    {
        int direction = (int)moveDirection; // 得到移动方向的整数值。
        // 如果当前UI映射包含移动方向。
        if (Array.IndexOf(GetCurrentUIMapping(), direction) != -1)
        {
            int nextIndex = GetNextUIIndex(direction); // 获取下一个UI索引。
            if (nextIndex != -1)
            {
                ChoseUI(nextIndex); // 根据下一个UI索引选择UI。
            }
        }
    }
}
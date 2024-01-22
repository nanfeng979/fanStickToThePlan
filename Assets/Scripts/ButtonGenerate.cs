using System;
using System.Collections.Generic;
using UnityEngine;
using Y9g;

public class ButtonGenerate : MonoBehaviour
{
    [SerializeField]
    protected GameObject UIGameobjectList;
    protected Dictionary<int, GameObject> UIMapping = new Dictionary<int, GameObject>();
    protected int previousUIIndex = 0;
    protected int currentUIIndex = 0;

    public string buttonColor;

    protected const int Up = (int)Move4Direction.Up;
    protected const int Down = (int)Move4Direction.Down;
    protected const int Left = (int)Move4Direction.Left;
    protected const int Right = (int)Move4Direction.Right;

    protected int[][] UIGraph;

    protected virtual void Start()
    {
        // 初始化UI映射。
        for (int i = 0; i < UIGameobjectList.transform.childCount; i++)
        {
            UIMapping.Add(i, UIGameobjectList.transform.GetChild(i).gameObject);
        }

        // 初始化UI颜色。
        ChangeUIColor(currentUIIndex);
    }

    protected virtual void Update()
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
    protected void ChoseUI(int index)
    {
        ChangeUIIndex(index);
        ChangeUIColor(index);
        PlaySound(0);
    }

    // 改变UI索引。
    protected void ChangeUIIndex(int index)
    {
        previousUIIndex = currentUIIndex; // 改变上一个UI索引。
        currentUIIndex = index; // 改变当前UI索引。
    }

    // 改变UI颜色。
    protected void ChangeUIColor(int index)
    {
        // 改变上一个UI颜色。
        GameObject previousUI = UIMapping[previousUIIndex];
        previousUI.transform.GetComponent<UnityEngine.UI.Button>().image.color = Y9g.Utils.HexToColor("#FFFFFF");

        // 改变当前UI颜色。
        GameObject currentUI = UIMapping[index];
        currentUI.transform.GetComponent<UnityEngine.UI.Button>().image.color = Y9g.Utils.HexToColor("#" + buttonColor);
    }

    // 播放音效。
    protected void PlaySound(int index)
    {
        SoundManager.Instance.PlaySound(index);
    }

    // 获取下一个UI索引。
    protected int GetNextUIIndex(int direction)
    {
        return Array.IndexOf(GetCurrentUIMapping(), direction);
    }

    // 获取当前UI映射。
    protected int[] GetCurrentUIMapping()
    {
        return UIGraph[GetUIIndex()];
    }

    // 获取当前UI索引。
    protected int GetUIIndex()
    {
        return currentUIIndex;
    }

    // 移动输入。
    protected void MoveInput(Move4Direction moveDirection)
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
using System;
using System.Collections.Generic;
using UnityEngine;
using Y9g;

public class ButtonGenerate : Page, IEscClick
{
    [SerializeField]
    protected GameObject UIGameobjectList;
    // protected Dictionary<int, GameObject> UIMapping = new Dictionary<int, GameObject>();
    protected List<GameObject> UIMapping = new List<GameObject>();
    protected int previousUIIndex = 0;
    protected int currentUIIndex = 0;

    public string buttonColor = "DB5454";

    # region UI const
    protected const int Up = (int)Move4Direction.Up;
    protected const int Down = (int)Move4Direction.Down;
    protected const int Left = (int)Move4Direction.Left;
    protected const int Right = (int)Move4Direction.Right;
    protected const int UpLeft = (int)Move8Direction.UpLeft;
    protected const int UpRight = (int)Move8Direction.UpRight;
    protected const int DownLeft = (int)Move8Direction.DownLeft;
    protected const int DownRight = (int)Move8Direction.DownRight;
    #endregion UI const

    protected int[][] UIGraph;

    protected virtual void Start()
    {
        // 初始化UI映射。
        for (int i = 0; i < UIGameobjectList.transform.childCount; i++)
        {
            UIMapping.Add(UIGameobjectList.transform.GetChild(i).gameObject);
        }

        // 初始化UI颜色。
        ChangeUIColor(currentUIIndex);
    }

    // 选择UI。
    protected void ChoseUI(int index)
    {
        ChangeUIIndex(index);
        PlaySound(0);
    }

    // 改变UI索引。
    protected void ChangeUIIndex(int index)
    {
        previousUIIndex = currentUIIndex; // 改变上一个UI索引。
        currentUIIndex = index; // 改变当前UI索引。
        ChangeUIColor(index);
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

    // 获取当前UI索引的UI游戏对象。
    public GameObject GetUIGameobject()
    {
        return UIMapping[GetUIIndex()];
    }

    // 重写获取当前对象
    public override GameObject GetCurrentObject()
    {
        return UIMapping[GetUIIndex()];
    }

    // 重新打开页面。
    protected override void Init()
    {
        ChangeUIIndex(0);
    }

    // 移动输入。
    public override void OnMoveDown(Move4Direction moveDirection)
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
        else
        {
            switch (moveDirection)
            {
                case Move4Direction.Up:
                    if (Array.IndexOf(GetCurrentUIMapping(), UpLeft) != -1 || Array.IndexOf(GetCurrentUIMapping(), UpRight) != -1)
                    {
                        int nextIndex;
                        if (Array.IndexOf(GetCurrentUIMapping(), UpLeft) != -1)
                        {
                            nextIndex = Array.IndexOf(GetCurrentUIMapping(), UpLeft);
                        }
                        else
                        {
                            nextIndex = Array.IndexOf(GetCurrentUIMapping(), UpRight);
                        }
                        ChoseUI(nextIndex);
                    }
                    break;
                case Move4Direction.Down:
                    if (Array.IndexOf(GetCurrentUIMapping(), DownLeft) != -1 || Array.IndexOf(GetCurrentUIMapping(), DownRight) != -1)
                    {
                        int nextIndex;
                        if (Array.IndexOf(GetCurrentUIMapping(), DownLeft) != -1)
                        {
                            nextIndex = Array.IndexOf(GetCurrentUIMapping(), DownLeft);
                        }
                        else
                        {
                            nextIndex = Array.IndexOf(GetCurrentUIMapping(), DownRight);
                        }
                        ChoseUI(nextIndex);
                    }
                    break;
                case Move4Direction.Left:
                    if (Array.IndexOf(GetCurrentUIMapping(), UpLeft) != -1 || Array.IndexOf(GetCurrentUIMapping(), DownLeft) != -1)
                    {
                        int nextIndex;
                        if (Array.IndexOf(GetCurrentUIMapping(), UpLeft) != -1)
                        {
                            nextIndex = Array.IndexOf(GetCurrentUIMapping(), UpLeft);
                        }
                        else
                        {
                            nextIndex = Array.IndexOf(GetCurrentUIMapping(), DownLeft);
                        }
                        ChoseUI(nextIndex);
                    }
                    break;
                case Move4Direction.Right:
                    if (Array.IndexOf(GetCurrentUIMapping(), UpRight) != -1 || Array.IndexOf(GetCurrentUIMapping(), DownRight) != -1)
                    {
                        int nextIndex;
                        if (Array.IndexOf(GetCurrentUIMapping(), UpRight) != -1)
                        {
                            nextIndex = Array.IndexOf(GetCurrentUIMapping(), UpRight);
                        }
                        else
                        {
                            nextIndex = Array.IndexOf(GetCurrentUIMapping(), DownRight);
                        }
                        ChoseUI(nextIndex);
                    }
                    break;
            }
        }
    }

    public virtual void Execute()
    {
        gameObject.SetActive(false);
    }
}
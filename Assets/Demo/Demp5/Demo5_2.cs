using System.Collections.Generic;
using UnityEngine;
using Y9g;

public class Demo5_2 : MonoBehaviour
{
    private Dictionary<int, List<int>> UIGraph = new Dictionary<int, List<int>>();
    [SerializeField]
    private GameObject UIGameobjectList;

    private Dictionary<int, GameObject> UIMapping = new Dictionary<int, GameObject>();
    private int previousUIIndex = 0;
    private int currentUIIndex = 0;

    public string buttonColor;

    const int Up = (int)Move8Direction.Up;
    const int Down = (int)Move8Direction.Down;
    const int Left = (int)Move8Direction.Left;
    const int Right = (int)Move8Direction.Right;
    const int UpLeft = (int)Move8Direction.UpLeft;
    const int UpRight = (int)Move8Direction.UpRight;
    const int DownLeft = (int)Move8Direction.DownLeft;
    const int DownRight = (int)Move8Direction.DownRight;

    void Start()
    {
        // 初始化UI图。
        UIGraph = new Dictionary<int, List<int>>()
        {
            {0, new List<int>(){0, DownLeft, 0, 0, 0}},
            {1, new List<int>(){Up, 0, DownRight, Left, 0}},
            {2, new List<int>(){0, UpLeft, 0, 0, 0}},
            {3, new List<int>(){0, UpRight, 0, 0, DownLeft}},
            {4, new List<int>(){0, 0, 0, UpRight, 0}},
        };

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

    private void ChangeUIColor(int index)
    {
        GameObject previousUI = UIMapping[previousUIIndex];
        previousUI.transform.GetComponent<UnityEngine.UI.Button>().image.color = Y9g.Utils.HexToColor("#FFFFFF");

        GameObject currentUI = UIMapping[index];
        currentUI.transform.GetComponent<UnityEngine.UI.Button>().image.color = Y9g.Utils.HexToColor("#" + buttonColor);
    }

    private void ChangeUIIndex(int index)
    {
        previousUIIndex = currentUIIndex;
        currentUIIndex = index;
    }

    private int GetUIIndex()
    {
        return currentUIIndex;
    }

    private void MoveInput(Move4Direction moveDirection)
    {
        switch (moveDirection)
        {
            case Move4Direction.Up:
                if (UIGraph[GetUIIndex()].Contains(Up) || UIGraph[GetUIIndex()].Contains(UpLeft) || UIGraph[GetUIIndex()].Contains(UpRight))
                {
                    int nextIndex;
                    if (UIGraph[GetUIIndex()].Contains(Up))
                    {
                        nextIndex = UIGraph[GetUIIndex()].IndexOf(Up);
                    }
                    else if (UIGraph[GetUIIndex()].Contains(UpLeft))
                    {
                        nextIndex = UIGraph[GetUIIndex()].IndexOf(UpLeft);
                    }
                    else
                    {
                        nextIndex = UIGraph[GetUIIndex()].IndexOf(UpRight);
                    }
                    ChangeUIIndex(nextIndex);
                    ChangeUIColor(GetUIIndex());
                }
                break;
            case Move4Direction.Down:
                if (UIGraph[GetUIIndex()].Contains(Down) || UIGraph[GetUIIndex()].Contains(DownLeft) || UIGraph[GetUIIndex()].Contains(DownRight))
                {
                    int nextIndex;
                    if (UIGraph[GetUIIndex()].Contains(Down))
                    {
                        nextIndex = UIGraph[GetUIIndex()].IndexOf(Down);
                    }
                    else if (UIGraph[GetUIIndex()].Contains(DownLeft))
                    {
                        nextIndex = UIGraph[GetUIIndex()].IndexOf(DownLeft);
                    }
                    else
                    {
                        nextIndex = UIGraph[GetUIIndex()].IndexOf(DownRight);
                    }
                    ChangeUIIndex(nextIndex);
                    ChangeUIColor(GetUIIndex());
                }
                break;
            case Move4Direction.Left:
                if (UIGraph[GetUIIndex()].Contains(Left) || UIGraph[GetUIIndex()].Contains(UpLeft) || UIGraph[GetUIIndex()].Contains(DownLeft))
                {
                    int nextIndex;
                    if (UIGraph[GetUIIndex()].Contains(Left))
                    {
                        nextIndex = UIGraph[GetUIIndex()].IndexOf(Left);
                    }
                    else if (UIGraph[GetUIIndex()].Contains(UpLeft))
                    {
                        nextIndex = UIGraph[GetUIIndex()].IndexOf(UpLeft);
                    }
                    else
                    {
                        nextIndex = UIGraph[GetUIIndex()].IndexOf(DownLeft);
                    }
                    ChangeUIIndex(nextIndex);
                    ChangeUIColor(GetUIIndex());
                }
                break;
            case Move4Direction.Right:
                if (UIGraph[GetUIIndex()].Contains(Right) || UIGraph[GetUIIndex()].Contains(UpRight) || UIGraph[GetUIIndex()].Contains(DownRight))
                {
                    int nextIndex;
                    if (UIGraph[GetUIIndex()].Contains(Right))
                    {
                        nextIndex = UIGraph[GetUIIndex()].IndexOf(Right);
                    }
                    else if (UIGraph[GetUIIndex()].Contains(UpRight))
                    {
                        nextIndex = UIGraph[GetUIIndex()].IndexOf(UpRight);
                    }
                    else
                    {
                        nextIndex = UIGraph[GetUIIndex()].IndexOf(DownRight);
                    }
                    ChangeUIIndex(nextIndex);
                    ChangeUIColor(GetUIIndex());
                }
                break;
        }
    }
}
using UnityEngine;
using Y9g;

/// <summary>
/// Confirm1。
/// Page。
/// </summary>
public class Confirm1 : ConfirmGenerate, IEscClick
{
    protected override void Start()
    {
        // 初始化UI图。
        UIGraph = new int[][]{
            new int[]{0, Right},
            new int[]{Left, 0},
        };

        // 注册事件。
        AddCurrentPageAllAction(InputManager.Instance.OutOnMoveDown);
        AddCurrentPageAllAction(InputManager.Instance.OutOnReturnDown);
        AddCurrentPageAllAction(InputManager.Instance.OutOnEscDown);
        AddCurrentPageAllAction(InputManager.Instance.OutOnSpaceDown);
        
        base.Start();
    }

    protected override void AcceptFunction()
    {
        Application.OpenURL("https://www.baidu.com");
    }

    protected override void CancelFunction()
    {
        gameObject.SetActive(false);
    }

    protected override void Init()
    {
        ChangeUIIndex(1);
    }
}
public class SetButtonUI : ButtonGenerate
{
    protected override void Start()
    {
        // 初始化UI图。
        UIGraph = new int[][]
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

        // 注册事件。
        AddCurrentPageAllAction(InputManager.Instance.OutOnMoveDown);
        AddCurrentPageAllAction(InputManager.Instance.OutOnReturnDown);
        AddCurrentPageAllAction(InputManager.Instance.OutOnEscDown);

        base.Start();
    }
}
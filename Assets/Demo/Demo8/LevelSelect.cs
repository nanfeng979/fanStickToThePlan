using Y9g;

public class LevelSelect : ButtonGenerate, IEscClick
{
    protected override void Start()
    {
        // 初始化UI图。
        UIGraph = new int[][]{
            new int[]{0, Down, 0},
            new int[]{Up, 0, Down},
            new int[]{0, Up, 0},
        };

        // 注册事件。
        AddCurrentPageAllAction(InputManager.Instance.OutOnMoveDown);
        AddCurrentPageAllAction(InputManager.Instance.OutOnEscDown);
        AddCurrentPageAllAction(InputManager.Instance.OutOnReturnDown);
        AddCurrentPageAllAction(InputManager.Instance.OutOnSpaceDown);

        base.Start();
    }
}
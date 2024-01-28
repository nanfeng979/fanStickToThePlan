public class ShouyeButtonUI : ButtonGenerate
{
    protected override void Start()
    {
        // 初始化UI图。
        UIGraph = new int[][]{
            new int[]{0, DownLeft, 0, 0, 0},
            new int[]{Up, 0, DownRight, Left, 0},
            new int[]{0, UpLeft, 0, 0, 0},
            new int[]{0, UpRight, 0, 0, DownLeft},
            new int[]{0, 0, 0, UpRight, 0},
        };

        base.Start();
    }

    public override void Execute()
    {
        UnityEngine.Debug.Log("ShouyeButtonUI Execute");
    }
}
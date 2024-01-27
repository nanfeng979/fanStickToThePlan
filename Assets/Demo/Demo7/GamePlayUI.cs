public class GamePlayUI : ButtonGenerate
{
    protected override void Start()
    {
        // 初始化UI图。
        UIGraph = new int[][]
        {
            new int[]{0, Down, 0, 0},
            new int[]{Up, 0, Down, 0},
            new int[]{0, Up, 0, Down},
            new int[]{0, 0, Up, 0},
        };

        base.Start();
    }
}
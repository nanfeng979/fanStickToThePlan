using UnityEngine;

public class ContinueClick : MonoBehaviour, Y9g.IButtonClick
{
    public void Execute()
    {
        // 隐藏父物体
        transform.parent.gameObject.SetActive(false);
    }
}
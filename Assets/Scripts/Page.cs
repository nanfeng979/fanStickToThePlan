using UnityEngine;

public abstract class Page : MonoBehaviour
{
    private event System.Action currentPageAllAction;

    private void OnEnable() {
        if (InputManager.Instance != null)
        {
            InputManager.Instance.AddNewPage(this);

            PreviousPageAllAction = InputManager.Instance.GetKeyDownEvent(); // 获取上一个页面的所有事件。
            // 清空前一个页面的所有事件。
            InputManager.Instance.ClearKeyDownEvent();
            // 注册当前页面的所有事件。
            InputManager.Instance.RegisterKeyDownEvent(CurrentPageAllAction);
        }
    }

    private void OnDisable() {
        if (InputManager.Instance != null)
        {
            InputManager.Instance.DeleteLastPage(this);
            Init();

            // 恢复上一个页面的所有事件。
            InputManager.Instance.ReSetKeyDownEvent(PreviousPageAllAction);
        }
    }

    protected virtual void Init() { }

    public virtual GameObject GetCurrentObject()
    {
        return null;
    }

    private event System.Action PreviousPageAllAction;
    public void CurrentPageAllAction() { currentPageAllAction?.Invoke(); }
    protected void AddCurrentPageAllAction(System.Action action)
    {
        currentPageAllAction += action;
    }
}
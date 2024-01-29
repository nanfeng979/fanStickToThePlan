using UnityEngine;
using Y9g;

public class InputManager : Singleton<InputManager>
{
    private event System.Action OnKeyDownListenerEvent;

    void Update()
    {
        OnKeyDownListenerEvent?.Invoke();
    }

    public void AddKeyDownEvent(System.Action action)
    {
        OnKeyDownListenerEvent += action;
    }

    public void SetKeyDownEvent(System.Action action)
    {
        OnKeyDownListenerEvent = action;
    }

    public System.Action GetKeyDownEvent()
    {
        return OnKeyDownListenerEvent;
    }

    public void ClearKeyDownEvent()
    {
        OnKeyDownListenerEvent = null;
    }

    public void OnCommand<T>() where T : ICommand
    {
        // 获取当前 Page 对象。
        Page currentPage = PageManager.Instance.GetCurrenPage();
        if (currentPage == null)
        {
            Debug.Log("currentPage is null");
            return;
        }

        ICommand currentCommand = currentPage.GetComponent<T>();
        if (currentCommand != null)
        {
            currentCommand.Execute();
        }
        else if (currentPage.GetCurrentObject() != null && currentPage.GetCurrentObject().GetComponent<T>() != null)
        {
            currentPage.GetCurrentObject().GetComponent<T>().Execute();
        }
        else
        {
            Debug.Log("currentCommand is null");
        }
    }

    public void AddNewPage(Page page)
    {
        PageManager.Instance.GetAllPages().Add(page);
        PageManager.Instance.ResetCurrentPage();
    }

    public void DeleteLastPage(Page page)
    {
        PageManager.Instance.GetAllPages().Remove(page);
        PageManager.Instance.ResetCurrentPage();
    }

    // -------- 常用的命令事件 --------
    public void OutOnMoveDown()
    {
        Page currentPage = PageManager.Instance.GetCurrenPage();
        if (currentPage == null)
        {
            Debug.Log("currentPage is null");
            return;
        }

        IMoveDown currentCommand = currentPage.GetComponent<IMoveDown>();
        if (currentCommand == null)
        {
            Debug.Log("currentCommand is null");
            return;
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentCommand.OnMoveDown(Move4Direction.Up);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentCommand.OnMoveDown(Move4Direction.Down);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentCommand.OnMoveDown(Move4Direction.Left);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentCommand.OnMoveDown(Move4Direction.Right);
        }
    }

    public void OutOnMove()
    {
        Page currentPage = PageManager.Instance.GetCurrenPage();
        if (currentPage == null)
        {
            Debug.Log("currentPage is null");
            return;
        }

        IMove currentCommand = currentPage.GetComponent<IMove>();
        if (currentCommand == null)
        {
            Debug.Log("currentCommand is null");
            return;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            currentCommand.OnMove(Move4Direction.Up);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            currentCommand.OnMove(Move4Direction.Down);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            currentCommand.OnMove(Move4Direction.Left);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            currentCommand.OnMove(Move4Direction.Right);
        }
    }

    public void OutOnReturnDown()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnCommand<IButtonClick>();
        }
    }

    public void OutOnEscDown()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnCommand<IEscClick>();
        }
    }
}
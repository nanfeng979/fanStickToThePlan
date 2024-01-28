using UnityEngine;
using Y9g;

public class InputManager : Singleton<InputManager>
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            PageManager.Instance.GetCurrenPage().OnMoveDown(Move4Direction.Up);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            PageManager.Instance.GetCurrenPage().OnMoveDown(Move4Direction.Down);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PageManager.Instance.GetCurrenPage().OnMoveDown(Move4Direction.Left);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            PageManager.Instance.GetCurrenPage().OnMoveDown(Move4Direction.Right);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            PageManager.Instance.GetCurrenPage().OnMove(Move4Direction.Up);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            PageManager.Instance.GetCurrenPage().OnMove(Move4Direction.Down);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            PageManager.Instance.GetCurrenPage().OnMove(Move4Direction.Left);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            PageManager.Instance.GetCurrenPage().OnMove(Move4Direction.Right);
        }


        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnCommand<IButtonClick>();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnCommand<IEscClick>();
        }
    }

    private void OnCommand<T>() where T : ICommand
    {
        // 获取当前 Page 对象。
        Page currentPage = PageManager.Instance.GetCurrenPage();
        if (currentPage != null)
        {
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
        else
        {
            Debug.Log("currentPage is null");
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
}
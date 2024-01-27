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
            // 获取当前焦点的 Button 对象。
            // GameObject currentButtonGameObject = currentPage.GetUIGameobject();
            // IButtonClick currentButtonClick = currentButtonGameObject.GetComponent<IButtonClick>();
            // if (currentButtonClick != null)
            // {
            //     currentButtonClick.OnButtonClick();
            // }

            // 获取当前 Page 对象。
            Page currentPage = PageManager.Instance.GetCurrenPage();
            if (currentPage != null)
            {
                GameObject currentButtonGameObject = currentPage.GetCurrentObject();
                IButtonClick currentButtonClickCommand = currentButtonGameObject.GetComponent<IButtonClick>();
                if (currentButtonClickCommand != null)
                {
                    currentButtonClickCommand.OnButtonClick();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 获取当前 Page 对象。
            Page currentPage = PageManager.Instance.GetCurrenPage();
            if (currentPage != null)
            {
                IEscClick currentEscCommand = currentPage.GetComponent<IEscClick>();
                if (currentEscCommand != null)
                {
                    currentEscCommand.OnEsc();
                }
            }
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
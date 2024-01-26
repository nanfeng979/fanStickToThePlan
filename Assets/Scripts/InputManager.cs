using UnityEngine;
using Y9g;

public class InputManager : Singleton<InputManager>
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            PageManager.Instance.GetCurrenPage().OnMove(Move4Direction.Up);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            PageManager.Instance.GetCurrenPage().OnMove(Move4Direction.Down);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PageManager.Instance.GetCurrenPage().OnMove(Move4Direction.Left);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
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

    public void AddNewPage(ButtonGenerate buttonGenerate)
    {
        PageManager.Instance.GetAllPages().Add(buttonGenerate);
        PageManager.Instance.ResetCurrentPage();
    }

    public void DeleteLastPage(ButtonGenerate buttonGenerate)
    {
        PageManager.Instance.GetAllPages().Remove(buttonGenerate);
        PageManager.Instance.ResetCurrentPage();
    }
}
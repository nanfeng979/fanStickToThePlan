using System.Collections.Generic;
using UnityEngine;
using Y9g;

public class ButtonInputManager : Singleton<ButtonInputManager>
{
    public List<ButtonGenerate> buttonGenerates = new List<ButtonGenerate>();
    private ButtonGenerate currentButtonGenerate;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentButtonGenerate.MoveInput(Move4Direction.Up);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentButtonGenerate.MoveInput(Move4Direction.Down);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentButtonGenerate.MoveInput(Move4Direction.Left);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentButtonGenerate.MoveInput(Move4Direction.Right);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            // 获取当前焦点的 Button 对象。
            GameObject currentButtonGameObject = currentButtonGenerate.GetUIGameobject();
            IButtonClick currentButtonClick = currentButtonGameObject.GetComponent<IButtonClick>();
            if (currentButtonClick != null)
            {
                currentButtonClick.OnButtonClick();
            }
        }
    }

    public void AddButtonGenerate(ButtonGenerate buttonGenerate)
    {
        buttonGenerates.Add(buttonGenerate);
        SetCurrentButtonGenerate();
    }

    public void DeleteButtonGenerate(ButtonGenerate buttonGenerate)
    {
        buttonGenerates.Remove(buttonGenerate);
        SetCurrentButtonGenerate();
    }

    private void SetCurrentButtonGenerate()
    {
        // 获取buttonGenerates最后一个元素。
        if (buttonGenerates.Count > 0)
        {
            currentButtonGenerate = buttonGenerates[buttonGenerates.Count - 1];
            Debug.Log("currentButtonGenerate is " + currentButtonGenerate);
        }
        else
        {
            currentButtonGenerate = null;
            Debug.Log("currentButtonGenerate is null");
        }
    }
}
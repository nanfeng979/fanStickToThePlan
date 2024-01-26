using System.Collections.Generic;
using UnityEngine;
using Y9g;

public class PageManager : Singleton<PageManager>
{
    public List<Page> allPages = new List<Page>();
    private Page currentPage;

    [SerializeField]
    private GameObject shouye;
    void Start()
    {
        FirstStart(shouye);
    }

    public Page GetCurrenPage()
    {
        return currentPage;
    }

    public void ResetCurrentPage()
    {
        // 获取 allPages 最后一个元素。
        if (GetAllPages().Count > 0)
        {
            currentPage = GetLastPage();
            Debug.Log("currentPage is " + currentPage);
        }
        else
        {
            currentPage = null;
            Debug.Log("currentPage is null");
        }
    }

    public List<Page> GetAllPages()
    {
        return allPages;
    }

    private Page GetLastPage()
    {
        if (allPages.Count > 0)
        {
            return allPages[allPages.Count - 1];
        }
        else
        {
            return null;
        }
    }

    private void FirstStart(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
}
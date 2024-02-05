using UnityEngine;
using Y9g;

public class LanguageClick : MonoBehaviour, IButtonClick
{
    [SerializeField]
    private int nextCount = 0;

    public void Execute()
    {
        LanguageManager.Instance.NextLanguage(nextCount);
    }
}
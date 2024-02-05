using UnityEngine;
using Y9g;

public class LanguageClick : MonoBehaviour, IButtonClick
{
    [SerializeField]
    private int nextCount = 0;

    [SerializeField]
    private UnityEngine.UI.Text languageText;

    public void Execute()
    {
        LanguageManager.Instance.NextLanguage(nextCount);
        languageText.text = LanguageManager.Instance.GetLanguageTypeName();
    }
}
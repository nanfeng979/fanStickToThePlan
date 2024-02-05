using UnityEngine;

public class GetLanguageType : MonoBehaviour
{
    void Start()
    {
        UnityEngine.UI.Text languageText = GetComponent<UnityEngine.UI.Text>();
        languageText.text = LanguageManager.Instance.GetLanguageTypeName();
    }
}
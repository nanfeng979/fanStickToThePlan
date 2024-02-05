using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UIText : MonoBehaviour
{
    public string key;
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
        text.text = LanguageManager.Instance.GetText(key);

        LanguageManager.Instance.RegisterObserver(this);
    }

    public void OnLanguageChanged()
    {
        text.text = LanguageManager.Instance.GetText(key);
    }
}
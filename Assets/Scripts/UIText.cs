using UnityEngine;
using UnityEngine.UI;
using Y9g;

[RequireComponent(typeof(Text))]
public class UIText : MonoBehaviour, IObserver
{
    public string key;
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
        text.text = LanguageManager.Instance.GetText(key);

        LanguageManager.Instance.RegisterObserver(this);
    }

    public void UpdateObserver()
    {
        text.text = LanguageManager.Instance.GetText(key);
    }

    private void OnDestroy()
    {
        LanguageManager.Instance.UnregisterObserver(this);
    }
}
using System.Collections.Generic;
using Y9g;
using Newtonsoft.Json;
using UnityEngine;

public class LanguageManager : Singleton<LanguageManager>
{
    // 语言文本字典。
    private Dictionary<string, string> languageDict = new Dictionary<string, string>();

    // 当前语言类型。
    private LanguageType currentLanguageType = LanguageType.zh;

    // 观察者列表。
    private List<UIText> observers = new List<UIText>();

    private void Start() {
        SetLanguageType(LanguageType.zh);
    }

    /// <summary>
    /// 加载指定的语言文本。
    /// </summary>
    /// <param name="languageType"> 语言类型 </param>
    private void LoadLanguageType(LanguageType languageType)
    {
        string jsonText = SystemIO.ReadJsonFromStreamingAssets("Language_" + languageType.ToString());
        languageDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonText);
        // 通知观察者。
        NotifyObservers();
    }

    /// <summary>
    /// 改变语言类型。
    /// </summary>
    /// <param name="languageType"> 语言类型 </param>
    private void SetLanguageType(LanguageType languageType)
    {
        currentLanguageType = languageType;
        LoadLanguageType(languageType);
    }

    public string GetText(string key)
    {
        if (languageDict.ContainsKey(key))
        {
            return languageDict[key];
        }
        return key + " not found";
    }

    /// <summary>
    /// 通知观察者。
    /// </summary>
    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.OnLanguageChanged();
        }
    }

    /// <summary>
    /// 注册观察者。
    /// </summary>
    /// <param name="observer"> 观察者 </param>
    public void RegisterObserver(UIText observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    /// <summary>
    /// 取消注册观察者。
    /// </summary>
    /// <param name="observer"> 观察者 </param>
    public void UnregisterObserver(UIText observer)
    {
        observers.Remove(observer);
    }

    public void NextLanguage(int next)
    {
        currentLanguageType = (LanguageType)(((int)currentLanguageType + next + LanguageType.GetValues(typeof(LanguageType)).Length) % LanguageType.GetValues(typeof(LanguageType)).Length);
        SetLanguageType(currentLanguageType);
    }
}

public enum LanguageType
{
    zh,
    en,
    jp,
}
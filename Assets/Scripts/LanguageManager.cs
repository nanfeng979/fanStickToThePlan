using System.Collections.Generic;
using Y9g;

public class LanguageManager : SingletonObserver<LanguageManager>
{
    // 语言文本字典。
    private Dictionary<string, string> languageDict = new Dictionary<string, string>();

    // 当前语言类型。
    private LanguageType currentLanguageType = LanguageType.zh;

    /// <summary>
    /// 加载指定的语言文本。
    /// </summary>
    /// <param name="languageType"> 语言类型 </param>
    private void LoadLanguageType(LanguageType languageType)
    {
        languageDict = SystemIO.ReadJsonFromStreamingAssets<Dictionary<string, string>>("Language_" + languageType.ToString());
        // 通知观察者。
        NotifyObservers();
    }

    /// <summary>
    /// 改变语言类型。
    /// </summary>
    /// <param name="languageType"> 语言类型 </param>
    public void SetLanguageType(LanguageType languageType)
    {
        currentLanguageType = languageType;
        LoadLanguageType(languageType);
    }

    /// <summary>
    /// 保存语言类型。
    /// </summary>
    public void SaveLanguageType()
    {
        // 更改游戏设置。
        GameSettingManager.Instance.SetGameSetting("语言类型", currentLanguageType.ToString());
        // 保存游戏设置。
        GameSettingManager.Instance.SaveGameSetting();
    }

    /// <summary>
    /// 获取对应的文本。
    /// </summary>
    /// <param name="key"> 键值 </param>
    /// <returns> 文本 </returns>
    public string GetText(string key)
    {
        if (languageDict.ContainsKey(key))
        {
            return languageDict[key];
        }
        return key + " not found";
    }

    /// <summary>
    /// 根据下一个步数，切换语言。
    /// </summary>
    /// <param name="nextStep"></param>
    public void NextLanguage(int nextStep)
    {
        currentLanguageType = EnumCalculate.GetOtherEnum(currentLanguageType, nextStep);
        SetLanguageType(currentLanguageType);
        SaveLanguageType();
    }

    /// <summary>
    /// 获取当前语言类型名称。
    /// </summary>
    /// <returns> 语言类型名称 </returns>
    public string GetLanguageTypeName()
    {
        switch (currentLanguageType)
        {
            case LanguageType.zh:
                return "中文";
            case LanguageType.en:
                return "英文";
            case LanguageType.jp:
                return "日文";
            default:
                return "未知";
        }
    }
}

public enum LanguageType
{
    zh,
    en,
    jp,
}
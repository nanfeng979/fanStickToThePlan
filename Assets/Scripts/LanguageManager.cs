using System.Collections.Generic;
using Y9g;
using Newtonsoft.Json;

public class LanguageManager : Singleton<LanguageManager>
{
    private Dictionary<string, string> languageDict = new Dictionary<string, string>();

    private void Start() {
        SetLanguageType(LanguageType.zh);
    }

    /// <summary>
    /// 加载指定的语言文本
    /// </summary>
    /// <param name="languageType"> 语言类型 </param>
    private void LoadLanguageType(LanguageType languageType)
    {
        string jsonText = SystemIO.ReadJsonFromStreamingAssets("Language_" + languageType.ToString());
        languageDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonText);
    }

    /// <summary>
    /// 设置语言
    /// </summary>
    /// <param name="languageType"> 语言类型 </param>
    public void SetLanguageType(LanguageType languageType)
    {
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
}

public enum LanguageType
{
    zh,
    en
}
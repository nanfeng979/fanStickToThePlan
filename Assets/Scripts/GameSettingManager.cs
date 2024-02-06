using System.Collections.Generic;
using Y9g;

public class GameSettingManager : Singleton<GameSettingManager>
{
    private Dictionary<string, string> gameSettingDict = new Dictionary<string, string>();

    void Start()
    {
        // 读取游戏设置。
        gameSettingDict = SystemIO.ReadJsonFromStreamingAssets<Dictionary<string, string>>("GameSetting");

        // 设置语言类型。
        LanguageType languageType = EnumCalculate.StringToEnum<LanguageType>(gameSettingDict["语言类型"]);
        LanguageManager.Instance.SetLanguageType(languageType);

        // 设置音乐值。
        float musicValue = Utils.PercentToFloat(gameSettingDict["音乐值"]);
        MusicManager.Instance.SetMusicValue(musicValue);

        // 设置音效值。
        float soundValue = Utils.PercentToFloat(gameSettingDict["音效值"]);
        SoundManager.Instance.SetSoundValue(soundValue);
        
    }

    /// <summary>
    /// 设置游戏设置。
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void SetGameSetting(string key, string value)
    {
        if (gameSettingDict.ContainsKey(key))
        {
            gameSettingDict[key] = value;
        }
        else
        {
            gameSettingDict.Add(key, value);
        }
    }

    /// <summary>
    /// 保存游戏设置。
    /// </summary>
    public void SaveGameSetting()
    {
        string json = Newtonsoft.Json.JsonConvert.SerializeObject(gameSettingDict);
        SystemIO.WriteJsonToStreamingAssets("GameSetting", json);
    }
}
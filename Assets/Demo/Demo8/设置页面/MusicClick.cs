using UnityEngine;
using UnityEngine.UI;

public class MusicClick : MonoBehaviour, Y9g.IButtonClick
{
    [SerializeField]
    private float volume = 10.0f;
    [SerializeField]
    private Text musicTextValue;

    public void Execute()
    {
        float currentVolume = Y9g.Utils.PercentToFloat(musicTextValue.text) * 100;
        currentVolume += volume;

        if (currentVolume > 100)
        {
            currentVolume = 100;
        }
        else if (currentVolume < 0)
        {
            currentVolume = 0;
        }

        musicTextValue.text = currentVolume + "%";

        MusicManager.Instance.SetMusicValue(Y9g.Utils.PercentToFloat(musicTextValue.text));

        GameSettingManager.Instance.SetGameSetting("音乐值", musicTextValue.text);
        GameSettingManager.Instance.SaveGameSetting();
    }
}
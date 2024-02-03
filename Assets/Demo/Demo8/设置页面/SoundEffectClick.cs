using UnityEngine;
using UnityEngine.UI;

public class SoundEffectClick : MonoBehaviour, Y9g.IButtonClick
{
    [SerializeField]
    private float volume = 10.0f;
    [SerializeField]
    private Text soundEffectTextValue;

    public void Execute()
    {
        float currentVolume = Y9g.Utils.PercentToFloat(soundEffectTextValue.text) * 100;
        currentVolume += volume;

        if (currentVolume > 100)
        {
            currentVolume = 100;
        }
        else if (currentVolume < 0)
        {
            currentVolume = 0;
        }

        soundEffectTextValue.text = currentVolume + "%";
    }
}
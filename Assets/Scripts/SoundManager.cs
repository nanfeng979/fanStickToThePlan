using UnityEngine;
using Y9g;

public class SoundManager : Singleton<SoundManager>
{
    public AudioClip[] audioClips;
    public AudioSource audioSource;

    public void PlaySound(int index)
    {
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }

    public void PlaySound(string name)
    {
        for (int i = 0; i < audioClips.Length; i++)
        {
            if (audioClips[i].name == name)
            {
                PlaySound(i);
                return;
            }
        }
    }

    public string GetSoundValue()
    {
        return audioSource.volume * 100 + "%";
    }

    public void SetSoundValue(float value)
    {
        audioSource.volume = value;
    }
}
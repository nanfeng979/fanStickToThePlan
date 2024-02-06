using UnityEngine;
using Y9g;

public class MusicManager : Singleton<MusicManager>
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    public string GetMusicValue()
    {
        return audioSource.volume * 100 + "%";
    }

    public void SetMusicValue(float value)
    {
        audioSource.volume = value;
    }
}
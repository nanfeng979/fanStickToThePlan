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
}
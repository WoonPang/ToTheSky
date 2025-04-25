using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] clips;

    private int currentIndex = 0;

    void Start()
    {
        if (clips.Length > 0)
        {
            PlayCurrentClip();
        }
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            NextClip();
        }
    }

    void PlayCurrentClip()
    {
        audioSource.clip = clips[currentIndex];
        audioSource.Play();
    }

    void NextClip()
    {
        currentIndex = (currentIndex + 1) % clips.Length; // ¼øÈ¯
        PlayCurrentClip();
    }
}

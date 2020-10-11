using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioClip correctAnswer, wrongAnswer, hoverSound, buttonOver, drumroll, winSound;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        instance = this;
    }

    public void PlayCorrectSound()
    {
        audioSource.PlayOneShot(correctAnswer, 1f);
    }

    public void PlayWrongSound()
    {
        audioSource.PlayOneShot(wrongAnswer, 1f);
    }

    public void PlayHoverSound()
    {
        audioSource.PlayOneShot(hoverSound, 0.5f);
    }

    public void PlayButtonOverSound()
    {
        audioSource.PlayOneShot(buttonOver, 0.5f);
    }

    public void PlayDrumroll()
    {
        audioSource.PlayOneShot(drumroll, 1f);
    }

    public void PlayWin()
    {
        audioSource.PlayOneShot(winSound, 1f);
    }
}

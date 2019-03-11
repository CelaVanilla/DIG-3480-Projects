using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip musicClipOne;

    public AudioClip musicClipTwo;

    public AudioSource musicSource;

    void Start()
    {
        musicSource.clip = musicClipOne;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            musicSource.clip = musicClipOne;
            musicSource.Play();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            musicSource.Stop();

        }
    }
}

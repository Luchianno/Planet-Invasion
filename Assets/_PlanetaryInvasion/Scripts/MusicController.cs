﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    AudioSource musicBackground;

    void Start()
    {
        musicBackground = GetComponent<AudioSource>();
    }

    public void SetAudioVolume(float volume)
    {
        musicBackground.volume = volume;
    }

    // TODO use crossfade
    public void ChangeMusic(AudioClip clip)
    {
        musicBackground.Stop();
        musicBackground.clip = clip;
        musicBackground.Play();
    }
}

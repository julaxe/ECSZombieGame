using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static GameObject soundManger;

    private static AudioSource _clipSource;
    private static AudioSource _musicSource;

    private AudioClip _menuMusic;

    private void Awake()
    {
        if (soundManger)
        {
            Destroy(this.gameObject);
            return;
        }

        soundManger = this.gameObject;
        var sources = GetComponents<AudioSource>();
        _clipSource = sources[0];
        _musicSource = sources[1];
    }

    private void Start()
    {
        _menuMusic = Resources.Load<AudioClip>("Sounds/MenuMusic");
        PlayMusic(_menuMusic);
        DontDestroyOnLoad(this);
    }

    public static void PlayClip(AudioClip clip)
    {
        _clipSource.PlayOneShot(clip);
    }

    public static void PlayMusic(AudioClip clip)
    {
        _musicSource.clip = clip;
        _musicSource.Play();
    }
}

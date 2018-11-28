using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
   
    public AudioSource[] sfx;
    public AudioSource[] music;

    public AudioMixer masterMixer;
    public AudioMixerGroup musicMixer;
    public AudioMixerGroup sfxMixer;

    // Singleton static instance.
    public static AudioManager Instance;

    // Random pitch adjustment range.
    public float LowPitchRange = .95f;
    public float HighPitchRange = 1.05f;



    // Initialize the singleton instance.
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        for (int i = 0; i < sfx.Length; i++)
        {
            sfx[i].outputAudioMixerGroup = sfxMixer;
        }

        for (int i = 0; i < music.Length; i++)
        {
            music[i].outputAudioMixerGroup = musicMixer;
        }

    }



    public void PlaySFX(int soundToPlay)
    {
        if (soundToPlay < sfx.Length)
        {
            
            sfx[soundToPlay].Play();
        }
    }
    public void PlaySFX(AudioClip soundToPlay)
    {
       for (int i = 0; i < sfx.Length; i++)
        {
            if (sfx[i] == soundToPlay)
            {
                sfx[i].Play();                
            }
        }
    }

    public void PlayMusic(int musicToPlay)
    {
        if (!music[musicToPlay].isPlaying)
        {
            StopMusic();
            if (musicToPlay < music.Length)
            {
                music[musicToPlay].Play();
            }
        }
            
    }

    public void PlayMusic(AudioClip musicToPlay)
    {
        for (int i = 0; i < sfx.Length; i++)
        {
            if (music[i] == musicToPlay)
            {
                if (!music[i].isPlaying)
                {
                    StopMusic();
                    music[i].Play();
                }
            }
        }
    }
    

    public void StopMusic()
    {
        for (int i = 0; i < music.Length; i++)
        {
            music[i].Stop();
        }
    }



}


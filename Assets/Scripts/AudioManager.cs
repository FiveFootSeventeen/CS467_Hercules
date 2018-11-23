using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // Audio players components.
    public AudioSource EffectsSource;
    public AudioSource MusicSource;


    public AudioSource[] sfx;
    public AudioSource[] music;



    // Singleton static instance.
    public static AudioManager Instance;

    // Random pitch adjustment range.
    public float LowPitchRange = .95f;
    public float HighPitchRange = 1.05f;

   


    [Header("Music")]


    private float musicVol = 1f;
    private float SFXVol = 1f;

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
        
        
    }

    // Play a single clip through the sound effects source.
    public void PlaySFX(AudioClip clip)
    {
        EffectsSource.clip = clip;
        EffectsSource.Play();
    }

    public void PlaySFX(int soundToPlay)
    {
        if (soundToPlay < sfx.Length)
        {
            sfx[soundToPlay].Play();
        }
    }

    // Play a single clip through the music source.
    public void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();
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
    
    public void StopMusic()
    {
        for (int i = 0; i < music.Length; i++)
        {
            music[i].Stop();
        }
    }

    private void Update()
    {

    }



}


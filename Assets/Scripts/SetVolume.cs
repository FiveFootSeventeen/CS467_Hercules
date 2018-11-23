using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer masterMixer;

    public void SetMusicVolume(float soundLevel)
    {
        masterMixer.SetFloat("musicVolume", Mathf.Log10(soundLevel) * 20);
    }

    public void SetSFXVolume(float soundLevel)
    {
        masterMixer.SetFloat("sfxVolume", Mathf.Log10(soundLevel) * 20);


    }

}

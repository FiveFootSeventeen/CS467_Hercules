using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{

    public AudioMixer masterMixer;

    public void SetMusicVolume(float soundLevel)
    {
        masterMixer.SetFloat("musicVol", Mathf.Log(soundLevel) * 20);
    }

    public void SetSFXVolume(float soundLevel)
    {
        masterMixer.SetFloat("sfxVol", Mathf.Log(soundLevel) * 20);
    }
}

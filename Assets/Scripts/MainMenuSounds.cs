using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSounds : MonoBehaviour {

    public AudioClip optionsFX;
    public AudioClip sliderMusic;
    public AudioClip sliderFX;
    
    public void musicVolCoroutine()
    {
        StopCoroutine(musicSliderVol());
        StartCoroutine(musicSliderVol());
    }

    // Use this for initialization
    public void optionsSound () {
        AudioManager.Instance.PlaySFX(optionsFX);
	}
    public IEnumerator musicSliderVol()
    {
        AudioManager.Instance.PlayMusic(sliderMusic);
        yield return new WaitForSecondsRealtime(3);
        AudioManager.Instance.MusicSource.Stop();
    }
    public void FXSliderVol()
    {
        AudioManager.Instance.PlaySFX(sliderFX);
    }
}
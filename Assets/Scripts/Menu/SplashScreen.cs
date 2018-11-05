using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

    [SerializeField] Animation _splashScreenAnimator;
    [SerializeField] AnimationClip _fadeOut;
    [SerializeField] AnimationClip _fadeIn;

    public void onFadeOutComplete()
    {
        Debug.LogWarning("FadeOut Complete");
    }

    public void onFadeInComplete()
    {
        Debug.LogWarning("FadeIn Complete");
    }

    public void FadeIn()
    {
        _splashScreenAnimator.Stop();
        _splashScreenAnimator.clip = _fadeIn;
        _splashScreenAnimator.Play();

    }

    public void FadeOut()
    {
        _splashScreenAnimator.Stop();
        _splashScreenAnimator.clip = _fadeOut;
        _splashScreenAnimator.Play();
    }
/*
    public void NewGame()
        {
            SceneManager.LoadScene(1);
        }

    public void LoadGame()
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene(2);
            GameController.control.Load();
        }

    public void Options()
        {

        }

    public void QuitGame()
        {
            //UnityEditor.EditorApplication.isPlaying = false;

            Application.Quit();
        
        }
        */
}

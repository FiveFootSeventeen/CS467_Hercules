using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour {

    public string levelToLoad;
    public string levelTransitionName;

    public float waitToLoad = 1f;
    private bool loadAfterFade;

    void Update ()
    {
        if (loadAfterFade)
        {
            waitToLoad -= Time.deltaTime;
            if (waitToLoad <= 0)
            {
                loadAfterFade = false;
                SceneManager.LoadScene(levelToLoad);
                if (levelToLoad == "Game.MainScene")
                {
                    CountdownTimer.instance.StopTimer();
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            loadAfterFade = true;
            UIFade.instance.Fade();
            PlayerController.instance.levelTransitionName = levelTransitionName;
        }
    }
}

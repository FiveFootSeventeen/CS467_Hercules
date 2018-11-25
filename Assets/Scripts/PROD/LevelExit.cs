using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour {

    public string levelToLoad;
    public string levelTransitionName;
    public LevelEntrance theEntrance;

    public float waitToLoad = 1f;
    private bool loadAfterFade;

    void Start()
    {
        theEntrance.transitionName = levelTransitionName;
    }

    void Update ()
    {
        if (loadAfterFade)
        {
            waitToLoad -= Time.deltaTime;
            if (waitToLoad <= 0)
            {
                loadAfterFade = false;
                SceneManager.LoadScene(levelToLoad);
                
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //SceneManager.LoadScene(levelToLoad);
            loadAfterFade = true;
            UIFade.instance.Fade();
            PlayerController.instance.levelTransitionName = levelTransitionName;
        }
    }
}

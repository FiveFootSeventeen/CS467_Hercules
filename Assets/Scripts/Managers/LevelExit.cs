using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour {

    public string levelToLoad;
    public string levelTransitionName;
    public LevelEntrance theEntrance;

    void Start()
    {
        theEntrance.transitionName = levelTransitionName;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(levelToLoad);
            PlayerController.instance.levelTransitionName = levelTransitionName;
        }
    }
}

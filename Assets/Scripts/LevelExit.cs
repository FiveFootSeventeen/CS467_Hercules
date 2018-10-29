using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour {

    [SerializeField] float loadDelay = 2f;

    void onTriggerEnter2D(Collider2D collider)
    {
        StartCoroutine(LoadNext());
    }

    IEnumerator LoadNext()
    {
        yield return new WaitForSecondsRealtime(loadDelay);

        var curScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curScene + 1);
    }
}

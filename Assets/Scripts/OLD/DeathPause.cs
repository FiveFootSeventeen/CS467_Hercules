using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPause : MonoBehaviour
{

    public bool gamePaused = false;
    public GameObject player;
    public GameObject DeathMenu;

    public IEnumerator DeathWait()
    {
        yield return new WaitForSecondsRealtime(1);
        DoLast();
    }

    void DoLast()
    {
        Time.timeScale = 0;
        gamePaused = true;
        Cursor.visible = true;
        transform.GetChild(0).gameObject.SetActive(true);
    }

    void Update()
    {
        if (player.GetComponent<PlayerController>().isAlive == false)
        {
            StartCoroutine(DeathWait());
        }

    }
}
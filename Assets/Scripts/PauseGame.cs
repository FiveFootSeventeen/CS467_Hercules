using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

    public bool gamePaused = false;
    public GameObject pauseMenu;

    void Update () {
	    if (Input.GetButtonDown("Cancel"))
        {
            if (gamePaused == false)
            {
                Time.timeScale = 0;
                gamePaused = true;
                Cursor.visible = true;
                //pauseMenu.SetActive(true);
                transform.GetChild(0).gameObject.SetActive(true);

            }
            else
            {
                //pauseMenu.SetActive(false);
                transform.GetChild(0).gameObject.SetActive(false);
                Cursor.visible = false;
                gamePaused = false;
                Time.timeScale = 1;
            }
        }	
	}
}

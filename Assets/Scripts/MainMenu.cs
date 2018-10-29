using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

public void NewGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(1);
    }

public void LoadGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(1);
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
}

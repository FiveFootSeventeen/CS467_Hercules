using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string newGameScene;

    public GameObject continueButton;


    public void Continue()
    {
        //only continue if game is saved
    }

    public void NewGame()
    {
        SceneManager.LoadScene(newGameScene);
    }

    public void Options()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }
}
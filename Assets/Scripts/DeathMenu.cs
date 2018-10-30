using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{

    public GameObject darkness;

    private void Start()
    {
        darkness.SetActive(false);
    }
    public void LoadGame()
    {
        GameController.control.Load();
    }

    public void MainMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chooseFemaleScript : MonoBehaviour {

    public AudioClip optionFX;

    // Use this for initialization
    void OnMouseDown()
    {
        GameController.control.characterSelect = 1;
        GameController.control.Save();
        AudioManager.Instance.Play(optionFX);
        SceneManager.LoadScene(2);
    }
}

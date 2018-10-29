using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseMaleCharacter : MonoBehaviour {

    public AudioClip optionFX;

	// Use this for initialization
	void OnMouseDown () {
        GameController.control.characterSelect = 0;
        GameController.control.Save();
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        AudioManager.Instance.Play(optionFX);
    }
	
}

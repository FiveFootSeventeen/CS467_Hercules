using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentLoader : MonoBehaviour {

    public GameObject UICanvas;
    public GameObject Audio;
    
   
   
    


    // Use this for initialization
    void Start () {
		if (UIFade.instance == null)
        {
           UIFade.instance = Instantiate(UICanvas).GetComponent<UIFade>();
        }
        
        
        
        if (AudioManager.Instance == null)
        {
            AudioManager.Instance = Instantiate(Audio).GetComponent<AudioManager>();
        }
       
	}

    void FixedUpdate()
    {
        if (PlayerController.instance == null && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game.MainScene"))
        {

            PlayerController.instance = CharacterSelector.instance.InstantiateCharacter();

        }
    }
   
}

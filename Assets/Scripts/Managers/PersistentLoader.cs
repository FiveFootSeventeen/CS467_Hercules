using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentLoader : MonoBehaviour {

    public GameObject UICanvas;
    public GameObject player;
    public GameObject Audio;
    

	// Use this for initialization
	void Start () {
		if (UIFade.instance == null)
        {
           UIFade.instance = Instantiate(UICanvas).GetComponent<UIFade>();
        }

        if (PlayerController.instance == null)
        {
            PlayerController.instance = Instantiate(player).GetComponent<PlayerController>();
        }

        if (AudioManager.Instance == null)
        {
            AudioManager.Instance = Instantiate(Audio).GetComponent<AudioManager>();
        }
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

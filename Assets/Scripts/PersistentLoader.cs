using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentLoader : MonoBehaviour {

    public GameObject UICanvas;
    public GameObject player;

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
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

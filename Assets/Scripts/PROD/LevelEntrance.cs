using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEntrance : MonoBehaviour {

    public string transitionName;

	// Use this for initialization
	void Start () {
		if (transitionName == PlayerController.instance.levelTransitionName)
        {
            PlayerController.instance.transform.position = transform.position; //find player and put at this point
        }
        UIFade.instance.Unfade();
	}

}

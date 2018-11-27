using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEntrance : MonoBehaviour {

    public string transitionName;

	// Use this for initialization
	void Start () {
		if (transitionName == PlayerController.instance.levelTransitionName)
        {
            PlayerController.instance.transform.position = new Vector3(transform.position.x, transform.position.y - .5f, transform.position.z); //find player and put at this point
        }
        UIFade.instance.Unfade();
	}

}

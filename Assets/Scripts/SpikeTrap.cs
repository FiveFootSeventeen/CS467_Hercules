﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        if (PlayerController.instance.GetComponent<CapsuleCollider2D>().IsTouchingLayers(LayerMask.GetMask("Spikes")))
        {
            PlayerController.instance.isAlive = false;
            
        }

    }

}

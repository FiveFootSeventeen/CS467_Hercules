using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private GameObject followObject;

    private Vector3 offset;


	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// LateUpdate is called once per frame, but it guaranteed to run after all items have been processed in update.
	void LateUpdate () {
        //Set the transform position of camera to player's transform position plus the offset
        transform.position = player.transform.position + offset;
	}
}

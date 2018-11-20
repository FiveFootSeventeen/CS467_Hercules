using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;

	
	void Start () {
        target = PlayerController.instance.transform;
	}
	
	// LateUpdate is called once per frame, but it guaranteed to run after all items have been processed in update.
	void Update () {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
	}
}

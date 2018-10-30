using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(this.gameObject);
        GameController.control.keysCollected = GameController.control.keysCollected + 1;

    }
}

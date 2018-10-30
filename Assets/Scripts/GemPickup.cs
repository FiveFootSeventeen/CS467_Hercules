using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickup : MonoBehaviour {

   
    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(this.gameObject);
        GameController.control.gemsCollected = GameController.control.gemsCollected + 1;
        
    }
}

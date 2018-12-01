using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaPuzzle : MonoBehaviour
{

    //GameController gameController;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //gameController = FindObjectOfType<GameController>();
        GameController.control.plasmaPortalStatus = 1;


    }
}

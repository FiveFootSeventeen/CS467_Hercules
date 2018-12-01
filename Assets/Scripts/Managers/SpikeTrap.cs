﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{

    public float spikeTimer = 2;
    private float timeLeft;
    private bool canDamage = true;

    // Use this for initialization
    void Start()
    {
        timeLeft = spikeTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canDamage)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0.0f)
            {
                canDamage = true;
                timeLeft = spikeTimer;
            }
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject colObject = collision.gameObject;
        if (colObject.tag == "Player" && canDamage)
        {
            if (PlayerController.instance.isAlive == true) //make sure sfx only plays once
            {
                AudioManager.Instance.PlaySFX(1);
            }
            PlayerController.instance.takeDamage(15);
            canDamage = false;
        }
    }
}


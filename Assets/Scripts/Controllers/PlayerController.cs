using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.AI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 1.05f;
    public float maxSpeed, attackTime;
    float originSpeed;
    private bool playerMoving, attacking;
    private float attackTimeCounter;
    Rigidbody2D body;
    CapsuleCollider2D bodycollider;
    Vector2 move, lastMove;
    
    private GameObject attackTarget;
    public bool isAlive = true;
    Transform playerTransform;
    CharacterStats stats;

    Animator animator;
    
    //CharacterStats stats;
    void Awake()
    {
        animator = GetComponent<Animator>();
        bodycollider = GetComponent<CapsuleCollider2D>();
        body = GetComponent<Rigidbody2D>();
        stats = GetComponent<CharacterStats>();

       
    }

    /// CALEB ADDED
   public SimpleHealthBar healthBar;
   public SimpleHealthBar sanityBar;

    void Start()
    {
        
        
             

    }

    void Update()
    {
        
    }

    public void Attack() 
    {
        var weapon = stats.GetCurrentWeapon();
        if (weapon != null)
        {
            StopAllCoroutines();
        }
        animator.SetBool("attacking", true);
        //animator.SetTrigger()

    }


   public void Spikes()
    {
        if (bodycollider.IsTouchingLayers(LayerMask.GetMask("Spikes")))
        {
            isAlive = false;
            playerMoving = false;
            int speed = 0;           
            animator.SetBool("playerMoving", playerMoving);
            body.velocity = new Vector2(speed, speed);
            animator.SetTrigger("Dying");            
        }
        
    }

}


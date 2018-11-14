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
    Rigidbody2D rigidbody;
    CapsuleCollider2D bodycollider;
    Vector2 move, lastMove;
    
    private GameObject attackTarget;
    public bool isAlive = true;
    Transform playerTransform; 

    Animator animator;
    
    //CharacterStats stats;
    void Awake()
    {
        animator = GetComponent<Animator>();
        bodycollider = GetComponent<CapsuleCollider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        
        
        //stats = null; //TODO
    }

    /// CALEB ADDED
    //public SimpleHealthBar healthBar;
    //public SimpleHealthBar sanityBar;

    void Start()
    {
        
        
             

    }

    void Update()
    {
        
    }

    public void WeaponHit() 
    {


    }
/*    public bool Spikes()
    {
        if (bodycollider.IsTouchingLayers(LayerMask.GetMask("Spikes")))
        {
            isAlive = false;
            playerMoving = false;
            int speed = 0;



            //TODO: Fix terrible Spaghetti code
            animator.SetFloat("lastVert", speed);
            animator.SetFloat("lastHorz", speed);

            animator.SetFloat("verticalSpeed", speed);
            animator.SetFloat("horizontalSpeed", speed);
            animator.SetBool("playerMoving", playerMoving);
            rigidbody2D.velocity = new Vector2(speed, speed);

            animator.SetTrigger("Dying");



            return true;
        }
        return false;
    }
*/ 
}


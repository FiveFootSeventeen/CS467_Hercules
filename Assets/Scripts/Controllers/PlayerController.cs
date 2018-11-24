using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.AI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    

    //Prevent duplicate players
    public static PlayerController instance;

    float moveSpeed;
    float originSpeed = 1.5f;
    public float runMultiplier = 2f;
    
    public float attackTime = 2f;
    public string levelTransitionName; //exit or entrance we just used
    protected bool attacking;
    protected float attackTimeCounter;

    public bool canMove = true;
    public bool playerMoving = false;

    public Rigidbody2D playerRB;
    CapsuleCollider2D bodycollider;
    Animator anim;

   
     double timeBtwnSteps = 0.317;
     double ellapsedStepTime;
   

    protected GameObject attackTarget;
    public bool isAlive = true;
    CharacterStats stats;

   
    void Awake()
    {
        anim = GetComponent<Animator>();
        bodycollider = GetComponent<CapsuleCollider2D>();
        playerRB = GetComponent<Rigidbody2D>();
        stats = GetComponent<CharacterStats>();
       
    }
   

    void Start()
    {
        if (instance == null) 
        {
            //When game starts, instance value set to this player
            instance = this;
        } else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }           
        }
        DontDestroyOnLoad(gameObject);
        /* Need to complete listeners first
        stats.characterDefinition.OnLevelUp.AddListener(GameManager.Instance.OnLevelUp);
        stats.characterDefinition.OnPlayerDMG.AddListener(GameManager.Instance.OnPlayerDMG);
        stats.characterDefinition.OnPlayerGainHP.AddListener(GameManager.Instance.OnPlayerGainHP);
        stats.characterDefinition.OnPlayerDeath.AddListener(GameManager.Instance.OnPlayerDeath);
        stats.characterDefinition.OnPlayerInit.AddListener(GameManager.Instance.OnPlayerInit);
        */
        //stats.characterDefinition.OnPlayerInit.Invoke();

       

        
        


    }

    void FixedUpdate()
    {
        if (!isAlive)
        {
            Death();
            return;           
        }

        /*

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Attack("slashAttack", 2.0f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack("thrustAttack", 1.0f);
        }
        */
        Move();
        


    }

    public void Attack(string attackType, float attackTime) 
    {
        var weapon = stats.GetCurrentWeapon();
        if (weapon != null)
        {
            StopAllCoroutines();
        }
        anim.SetBool("attacking", true);
        anim.SetTrigger(attackType);
        attacking = true;
        attackTimeCounter = attackTime;

        while (attackTimeCounter > 0) 
        {
            attackTimeCounter -= Time.deltaTime;
        }

        attacking = false;
        anim.SetBool("attacking", false);
    }


    public void Move()
    {
        
        playerMoving = false;
        if (canMove)
        {
            if (Input.GetKey("left shift") || Input.GetKey("right shift"))  //Add the running multiplier
            {
                moveSpeed = originSpeed * runMultiplier;
                anim.speed = 1.5F;                        //Increase the animation speed for running
            }
            else
            {
                anim.speed = 1;
            }
            playerRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
            
        }
        else
        {
            playerRB.velocity = Vector2.zero;
        }


        anim.SetFloat("moveX", playerRB.velocity.x);
        anim.SetFloat("moveY", playerRB.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            playerMoving = true;
            ellapsedStepTime += Time.deltaTime;
            if (ellapsedStepTime >= timeBtwnSteps)
            {
                PlayWalkSound();
                ellapsedStepTime -= timeBtwnSteps;
            }


            if (canMove)
            {
                anim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
                anim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
            }
            
        }
        moveSpeed = originSpeed;
    }

    public void Death()
    {
        canMove = false;
        anim.SetBool("playerMoving", false);
        playerRB.velocity = Vector2.zero;
        anim.SetTrigger("Dying");    
    
    }


    public void PlayWalkSound()
    {
        AudioManager.Instance.PlaySFX(0);
    }

}

/*
 * if (!isAlive) { return; }
        move = Vector2.zero;
        playerMoving = false;

        if(Input.GetKeyDown("space"))
        {
            anim.SetBool("attacking", true); //Set the specified trigger in the animator
            anim.SetTrigger(action);
            attacking = true;
            attackTimeCounter = attackTime;
        }

        if (attackTimeCounter > 0)
            attackTimeCounter -= Time.deltaTime;
        else
        {
            attacking = false;
            anim.SetBool("attacking", false);
        }


        if (!attacking)
        {
            if (Input.GetKey("left shift") || Input.GetKey("right shift"))  //Add the running multiplier
            {
                maxSpeed = 4 * runSpeedMultiplier;
                anim.speed = 2F;                        //Increase the animation speed for running
            }
            else
            {
                anim.speed = 1;
            }

            lastMove.x = move.x = Mathf.Lerp(0, Input.GetAxis("Horizontal") * maxSpeed, 0.8f); //Get the horizontal axis, interpolate between 0 and the input by 0.8
            lastMove.y = move.y = Mathf.Lerp(0, Input.GetAxis("Vertical") * maxSpeed, 0.8f);   //Get the vertical axis, interpolate between 0 and the input by 0.8
        }

        if (move.x != 0f || move.y != 0)
        {
            playerMoving = true;
            ellapsedStepTime += Time.deltaTime;
            if (ellapsedStepTime >= timeBtwnSteps)
            {
               
                ellapsedStepTime -= timeBtwnSteps;
            }


            SetLastParams(lastMove);
        }
*/
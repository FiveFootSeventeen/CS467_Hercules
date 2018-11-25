using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public string levelTransitionName; //exit or entrance we just used

   
    public float runSpeedMultiplier = 1.05f;
    public float maxSpeed = 1.5f;
    public float attackTime = 1f;
    public float originSpeed = 1f;
    private bool playerMoving, attacking;
    private float attackTimeCounter;

    Vector2 move, lastMove;
    string action = "slashAttack";

    public bool isAlive = true;

    public WeaponSlot weapon;
    CharacterStats stats;
    CharacterStats_SO currentStats;
    Animator anim;
    new Rigidbody2D rigidbody2D;
    CapsuleCollider2D bodycollider;


    [Header("Effects")]
    public int walkFX;
   
    double timeBtwnSteps = 0.317;
    double ellapsedStepTime;

    void Awake()
    {
        if (instance == null)
        {
            //When game starts, instance value set to this player
            instance = this;
        }
        
        DontDestroyOnLoad(gameObject);
    }

    

    void Start()
    {
        

        anim = GetComponent<Animator>();
        bodycollider = GetComponent<CapsuleCollider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        stats = GetComponent<CharacterStats>();
        currentStats = stats.characterDefinition;


    }

    void FixedUpdate()
    {
        if (currentStats.currentHealth <= 0 && isAlive)        //Once the Player is dead destroy the game object
        {
            StartCoroutine(playerDead());
        }
        move = Vector2.zero;
        playerMoving = false;
        var currentWeapon = stats.GetCurrentWeapon();
        if (currentWeapon != null)
        {
            StopAllCoroutines();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            anim.SetBool("attacking", true); //Set the specified trigger in the animator
            anim.SetTrigger("slashAttack");
            attacking = true;
            weapon.isAttacking = true;
            attackTimeCounter = attackTime;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("attacking", true); //Set the specified trigger in the animator
            anim.SetTrigger("thrustAttack");
            attacking = true;
            weapon.isAttacking = true;
            attackTimeCounter = attackTime;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetBool("attacking", true); //Set the specified trigger in the animator
            anim.SetTrigger("castSpell");
            attacking = true;
            weapon.isAttacking = true;
            attackTimeCounter = attackTime;
        }

        if (attackTimeCounter > 0)
            attackTimeCounter -= Time.deltaTime;
        else
        {
            attacking = false;
            weapon.isAttacking = false;
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
                PlayWalkSound();
                ellapsedStepTime -= timeBtwnSteps;
            }
            SetLastParams(lastMove);
        }

        anim.SetFloat("verticalSpeed", move.x);     //verticalSpeed variable in the animator controller to move.x
        anim.SetFloat("horizontalSpeed", move.y);   //horizontalSpeed variable in the animator controller to move.y
        anim.SetBool("playerMoving", playerMoving); //Set the playerMoving parameter in the animator

        rigidbody2D.velocity = new Vector2(move.x, move.y);    //Move the player
        maxSpeed = originSpeed;     //Reset the player's speed
        
    }

    IEnumerator playerDead()
    {
        isAlive = false;
        playerMoving = false;
        int speed = 0;
        anim.SetBool("playerMoving", playerMoving);
        rigidbody2D.velocity = new Vector2(speed, speed);
        anim.SetTrigger("Dying");
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    private void SetLastParams(Vector2 lastMove)
    {
        Vector2 lastParams = new Vector2(lastMove.x, lastMove.y);

        lastMove.x = Mathf.Abs(lastMove.x);     //Set x and y to their absolute values
        lastMove.y = Mathf.Abs(lastMove.y);

        lastParams.x = lastParams.x >= 0 ? 1 : -1;  //The x and y values of lastParams must be either 1 or -1 to make the animation transitions work correctly
        lastParams.y = lastParams.y >= 0 ? 1 : -1;

        if (lastMove.x >= lastMove.y)       //For animation transistion to work correctly either x or y must be 0
            lastParams.y = 0;               //Look at the values of lastMove and keep the greater value as 1 or -1, change the lesser value to 0
        else
            lastParams.x = 0;

        anim.SetFloat("lastVert", lastParams.x);      //lastVert variable in the animator controller to move.x
        anim.SetFloat("lastHorz", lastParams.y);      //lastHorz variable in the animator controller to move.y
    }

    public void PlayWalkSound()
    {
        AudioManager.Instance.PlaySFX(walkFX);
    }
}


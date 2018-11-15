using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPCController : MonoBehaviour {

    public float patTime = 5;
    public float aggroRange = 3;
    
    public AudioClip spellAudio;
    public Events.EventEnemyDeath OnEnemyDeath;
 
    Rigidbody2D body;
    CapsuleCollider2D bodyCollider;

//Control movement 
    Transform playerTransform;
    private Animator animator;
    bool aggro = false;
    bool waiting = false;
    private float distanceFromTarget;
    public bool inView;

    public AttackSystem attack;

    Vector3 direction;
    public float walkSpeed = 2f;
    private int curTarget;
    public Transform[] waypointList;

    int index;

    float speed, enemySpeed;
    public float runSpeedMultiplier = 1.05f;
    //public float maxSpeed = 1f; //The fastest the enemy can run
    public float attackCooldown = 3f; //The time between enemy attacks
    private float lastAttack;
    private bool playerAlive;
    public float attackDistance = 1.25f; //The furthest the enemy can be before they will attack

    private void Awake()    
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        bodyCollider = GetComponent<CapsuleCollider2D>();

        playerTransform= GameObject.FindGameObjectWithTag("Player").transform;
        index = Random.Range(0, waypointList.Length);

        EnemyManager enemyManager = FindObjectOfType<EnemyManager>();
        if (enemyManager != null) 
            OnEnemyDeath.AddListener(enemyManager.OnEnemyDeath);
        
        InvokeRepeating("Tick", 0, 0.5f);

        if (waypointList.Length > 0)
        {
            InvokeRepeating("Pat", Random.Range(0, patTime), patTime);
        }

        lastAttack = float.MinValue;
        playerAlive = true;

        playerTransform.gameObject.GetComponent<DestroyedEvent>().IDied += PlayerDeath;
    }

    private void PlayerDeath()
    {
        playerAlive = false;
    }

    void Update()
    {
        speed = Mathf.Lerp(speed, body.velocity.magnitude, Time.deltaTime * 10);
        animator.SetFloat("Speed", speed);

        float timeSinceLastAttack = Time.time - lastAttack;
        bool attackOnCooldown = timeSinceLastAttack < attack.Cooldown;

        
    }

    public void useAttack()
    {
        if (!playerAlive)
            return;
        if (attack is Weapon) //TODO
        {
            return;
            //((Weapon)attack).Swing(gameObject, playerTransform.gameObject);
        } 
       // else if (attack is Spell) 
       // {
            return; //TODO
      //  }
    }
    
    void Pat()
    {
        index = index == waypointList.Length - 1 ? 0 : index + 1; 
    }

    void Tick()
    {
        //Move enemies to waypoint unless player is near, then aggro
        if (playerTransform != null && Vector3.Distance(transform.position, playerTransform.transform.position) < aggroRange)
        {
            body.MovePosition(playerTransform.transform.position); //Move to player position
        }

    }
}
    //Move the enemies based on the player's location
    
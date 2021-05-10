using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public PlayerStats playerData;
    [HideInInspector]public GameObject shootSpawn;
    public bool shooting;
    [HideInInspector] public GameObject groundPoint;
    public float checkRadius;
    [HideInInspector] public LayerMask groundLayer;
    public bool grounded;
    [HideInInspector] public GameObject laserPrefab;
    [HideInInspector] public Vector3 movement;
    public bool canShoot;
    [HideInInspector] public static PlayerController instance;
    [HideInInspector] public PlayerShooting playerShooting;
    public bool canAttack;
    public bool attack;
    [HideInInspector] public Animator playerAnimator;
    public Rigidbody playerRigidbody;
    private float horizontalInput;
    private float verticalInput;
    public bool jumping;
    public bool sliding;
    public bool blocking;
    public bool special;
    [HideInInspector] public bool diing;
    public bool dead;
    [HideInInspector] public AudioClip laserSound;
    [HideInInspector] public AudioClip hurtSound;
    [HideInInspector] public AudioClip blockSound;
    [HideInInspector] public AudioClip healSound;
    [HideInInspector] public AudioSource playerAudio;
    [HideInInspector] public GameObject hurtArea;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerData = new PlayerStats(1);
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerShooting = GetComponent<PlayerShooting>();
        shooting = false;
        canAttack = true;
        blocking = false;
        hurtArea = transform.Find("HurtArea").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!diing && !dead)
        {
            CheckGround();
            MovePlayer();
            RotatePlayer();
            Jump();
            Slide();
            Shoot();
            Attack();
            Block();
            Special();
        }
        else if (diing && !dead)
        {
            playerAnimator.SetTrigger("dead");
            dead = true;
        }
        
    }

    private void FixedUpdate()
    {
        playerAnimator.SetFloat("velocity", movement.magnitude);
        playerAnimator.SetBool("shooting", shooting);
        playerAnimator.SetBool("blocking", blocking);

        if (shooting)
        {
            playerShooting.SpawnLaser();
        }

        if (jumping)
        {
            playerAnimator.SetTrigger("jump");
            jumping = false;
        }

        if (sliding)
        {
            playerAnimator.SetTrigger("slide");
            sliding = false;
        }

        if (special)
        {
            playerAnimator.SetTrigger("special");
            special = false;
        }

    }

    private void Special() 
    {
        if (Input.GetButtonDown("Special"))
        {
            special = true;
        }
    }

    private void Block() 
    {
        if (Input.GetAxis("Block") > 0.1)
        {
            blocking = true;
        }
        else
        {
            blocking = false;
        }
    }

    private void Attack() 
    {
        if (Input.GetButtonDown("Attack") && !shooting && !sliding) 
        {
            //print("has pulsado la X");
            if (canAttack)
            {
                //print("attack = true");
                attack = true;
                canAttack = false;
            }
            else 
            {
                return;
            }
        }
    }

    public void AttackInputManager()
    {
        if (!canAttack)
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }
    }

    private void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        movement = new Vector3(horizontalInput, 0, verticalInput).normalized * playerData.moveSpeed;

        playerRigidbody.velocity = new Vector3 (movement.x, playerRigidbody.velocity.y, movement.z);
        
    }

    private void RotatePlayer()
    {
        if (movement.magnitude > 0) 
        {
            transform.rotation = Quaternion.LookRotation(movement, Vector3.up);
        }
    }

    private void Shoot() 
    {
        if (Input.GetAxis("Shoot") > 0.1 && canShoot)
        {
            shooting = true;
        }
        else 
        {
            shooting = false;
        }
    }

    private void Jump() 
    {
        if (Input.GetButtonDown("Jump") && grounded && !shooting && !sliding && !jumping) 
        {
            playerRigidbody.useGravity = false;
            jumping = true;     
        }
    }

    private void Slide() 
    {
        if (Input.GetButtonDown("Slide") && grounded && !shooting && !jumping && !sliding) 
        {
            playerRigidbody.useGravity = false;
            sliding = true;
        }
    }

    private void ResetSlide() 
    {
        sliding = false;
        playerRigidbody.useGravity = true;
    }

    private void CheckGround() 
    {
        Vector3 point = groundPoint.transform.position;

        if (Physics.OverlapSphere(point, checkRadius, groundLayer).Length > 0)
        {
            grounded = true;
            playerAnimator.applyRootMotion = true;
            
            canShoot = true; 
        }
        else 
        {
            grounded = false;
            playerAnimator.applyRootMotion = false;
            canShoot = false;
        }
    }

    public void resetGravity() {
        playerRigidbody.useGravity = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int moveSpeed;
    public float jumpForce;
    public GameObject shootSpawn;
    public bool shooting;
    public GameObject groundPoint;
    public float checkRadius;
    public LayerMask groundLayer;
    public bool grounded;
    public GameObject laserPrefab;
    public Vector3 movement;
    public bool canShoot;
    public static PlayerController instance;
    public float shootingRatio;
    public bool canAttack;
    public bool attack;
    public float damage;
    public Animator playerAnimator;
    private Rigidbody playerRigidbody;
    private float horizontalInput;
    private float verticalInput;
    private bool jumping;
    private bool sliding;
    private bool attacking;
    private float time = 0f;
    public bool blocking;
    private bool special;
    public bool diing;
    public bool dead;
    public AudioClip laserSound;
    public AudioClip hurtSound;
    public AudioSource playerAudio;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        shooting = false;
        canAttack = true;
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
            Timer();
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
            SpawnLaser();
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

    private void DamageChecker() 
    {
        /*if (Input.GetKeyDown(KeyCode.A)) 
        {
            playerAnimator.SetTrigger("hurt");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnimator.SetTrigger("dead");
        }*/
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

        movement = new Vector3(horizontalInput, 0, verticalInput).normalized * moveSpeed;

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

    public void SpawnLaser() 
    {
        if (shooting && time == 0)
        {
            playerAudio.PlayOneShot(laserSound);
            Instantiate(laserPrefab, shootSpawn.transform.position, transform.rotation);
            time = shootingRatio;
        }
    }

    private void Jump() 
    {
        if (Input.GetButtonDown("Jump") && grounded && !shooting && !sliding && !jumping) 
        {
            playerRigidbody.AddForce(movement*jumpForce,ForceMode.VelocityChange);
            jumping = true;     
        }
    }

    private void Slide() 
    {
        if (Input.GetButtonDown("Slide") && grounded && !shooting && !jumping && !sliding) 
        {
            sliding = true;
        }
    }

    private void ResetSlide() 
    {
        sliding = false;
    }

    private void CheckGround() 
    {
        Vector3 point = groundPoint.transform.position;

        if (Physics.OverlapSphere(point, checkRadius, groundLayer).Length > 0)
        {
            grounded = true;
            playerAnimator.applyRootMotion = true;
        }
        else 
        {
            grounded = false;
            playerAnimator.applyRootMotion = false;
        }
    }

    private void Timer() 
    {
        time -= 1 * Time.deltaTime;
        if (time < 0) 
        {
            time = 0f;
        }
    }
}

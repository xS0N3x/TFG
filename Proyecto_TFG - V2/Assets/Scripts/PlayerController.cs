using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int moveSpeed;
    public int jumpForce;
    public GameObject shootSpawn;
    public bool shooting;
    public GameObject groundPoint;
    public float checkRadius;
    public LayerMask groundLayer;
    public bool grounded;
    public GameObject laserPrefab;
    public Vector3 movement;

    private Animator playerAnimator;
    private Rigidbody playerRigidbody;
    private float horizontalInput;
    private float verticalInput;
    private bool jump;
    //private float time = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        shooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();
        /*Timer();*/
        MovePlayer();
        RotatePlayer();
        Jump();
        Shoot();
    }

    private void FixedUpdate()
    {
        playerAnimator.SetFloat("velocity", movement.magnitude);
        playerAnimator.SetBool("shooting", shooting);
        if (jump) 
        {
            playerAnimator.SetTrigger("jump");
            playerRigidbody.AddForce(new Vector3(jumpForce, 0, 0), ForceMode.Impulse);
            jump = false;
        }
    }

    private void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        movement = new Vector3(horizontalInput, 0, verticalInput).normalized * moveSpeed;

        playerRigidbody.velocity = new Vector3(horizontalInput, 0, verticalInput).normalized * moveSpeed;
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
        if (Input.GetAxis("Shoot") > 0.1)
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
        if (shooting) 
        {
            Instantiate(laserPrefab, shootSpawn.transform.position, transform.rotation);
        }
    }

    private void Jump() 
    {
        Vector3 jumpVector = new Vector3(0, jumpForce, 0);

        if (Input.GetButtonDown("Jump") && grounded && !shooting) 
        {
            jump = true;
        }
    }

    private void CheckGround() 
    {
        Vector3 point = groundPoint.transform.position;

        if (Physics.OverlapSphere(point, checkRadius, groundLayer).Length > 0)
        {
            grounded = true;
        }
        else 
        {
            grounded = false;
        }
    }

    /*private void Timer() 
    {
        time -= -1 * Time.deltaTime;
    }*/
}

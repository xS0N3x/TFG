using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Rigidbody enemyRigidbody;
    public Animator enemyAnimator;
    private bool jumped;
    public bool dead;
    private Collider enemyCollider;
    public GameObject target;
    public bool canAttack;
    public float turnSpeed;
    public GameObject hurtArea;

    // Start is called before the first frame update
    void Start()
    {
        canAttack = true;
        enemyRigidbody = GetComponent<Rigidbody>();
        enemyAnimator = GetComponent<Animator>();
        enemyCollider = GetComponent<Collider>();
        jumped = false;
        hurtArea = transform.Find("HurtArea").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            //Al morir bloqueamos el movimiento, la rotación, la velocidad restante y las colisiones.
            agent.isStopped = true;
            enemyRigidbody.freezeRotation = true;
            enemyRigidbody.velocity = Vector3.zero;
            enemyCollider.enabled = false;
            hurtArea.SetActive(false);
        }
        else 
        {
            Movement();
            Jumping();
        }

    }

    private void Movement() 
    {

        if ((transform.position - target.transform.position).magnitude > 2)
        {
            enemyAnimator.SetFloat("velocity", 1);
        }
        else if ((transform.position - target.transform.position).magnitude > 0) 
        {
            //On Range
            agent.isStopped = true;
            enemyAnimator.SetFloat("velocity", 0);

            //Look at the Player
            Vector3 targetDir = target.transform.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(targetDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);


            if (canAttack) 
            {
                enemyAnimator.SetTrigger("basicAttack");
                canAttack = false;
            }
            
        }
        else
        {
            enemyAnimator.SetFloat("velocity", 0);
        }
    }

    private void Jumping() 
    {
        if (agent.isOnOffMeshLink && !jumped)
        {
            enemyAnimator.SetTrigger("jump");
            jumped = true;
        }
        else if (!agent.isOnOffMeshLink)
        {
            jumped = false;
        }
    }

    private void resetNavMesh() {
        agent.isStopped = false;
        canAttack = true;
    }
}

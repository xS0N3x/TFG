using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyController enemyController;
    public HealthController healthController;
    public GameObject target;
    public float turnSpeed;
    public LayerMask playerLayer;
    //public LineRenderer lineRenderer;
    public GameObject player;
    private bool canShoot;
    public bool laserDetected;
    public GameObject laser;
    private bool dodgeReset;
    public bool shield;

    // Start is called before the first frame update
    void Start()
    {
        healthController = GetComponent<HealthController>();
        enemyController = GetComponent<EnemyController>();
        turnSpeed = 5;
        //lineRenderer = GetComponent<LineRenderer>();
        dodgeReset = false;
        shield = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BasicEnemyMovement() 
    {
        if (target != null)
        {
            enemyController.agent.SetDestination(target.transform.position);

            if ((transform.position - target.transform.position).magnitude < 2) //Attacking
            {
                //On Range
                enemyController.agent.isStopped = true;
                enemyController.enemyAnimator.SetFloat("velocity", 0);

                //Look at the Player
                Vector3 targetDir = target.transform.position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(targetDir);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);


                if (enemyController.canAttack)
                {
                    enemyController.enemyAnimator.SetTrigger("basicAttack");
                    enemyController.canAttack = false;
                }

            }
            else //Chasing Player
            {
                enemyController.enemyAnimator.SetFloat("velocity", 1);
                Jumping();
            }
        }
        else //Out of Range
        {
            enemyController.enemyAnimator.SetFloat("velocity", 0);
            enemyController.agent.SetDestination(transform.position);
        }
    }

    public void RangedEnemyMovement() {
        if (target != null)
        {
            enemyController.enemyAnimator.SetBool("shooting", false);

            float distanceToPlayer = Vector3.Distance(transform.position, target.transform.position);

            Vector3 direction = transform.position - target.transform.position;
            Vector3 destination = transform.position + direction;

            enemyController.agent.SetDestination(destination);
            enemyController.enemyAnimator.SetFloat("velocity", 1);

        }
        else
        {
            enemyController.agent.SetDestination(transform.position);
            enemyController.enemyAnimator.SetFloat("velocity", 0);

            //Look at the Player
            Vector3 targetDir = player.transform.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(targetDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed * 0.8f);

            if (canShoot) 
            {
                //Shoot
                enemyController.enemyAnimator.SetBool("shooting", true);
                enemyController.enemyShooting.SpawnLaser();
            }          
        }
    }

    public void QuickEnemyMovement()
    {
        if (target != null)
        {
            Vector3 newDirection = transform.position;
            int dice;

            if (laserDetected && !dodgeReset)
            {
                Vector3 laserDirection = transform.position - laser.transform.position;
                dice = Random.Range(0, 1);
                if (dice == 0)
                {
                    newDirection = new Vector3(-laserDirection.z, 0, laserDirection.x);
                }
                else
                {
                    newDirection = new Vector3(laserDirection.z, 0, -laserDirection.x);
                }
                enemyController.agent.SetDestination(newDirection);
                enemyController.enemyAnimator.SetTrigger("slide");
                StartCoroutine(ResetLaserDetection());
            }
            else if (!dodgeReset)
            {
                enemyController.agent.SetDestination(target.transform.position);
            }


            if ((transform.position - target.transform.position).magnitude < 2) //Attacking
            {
                //On Range
                enemyController.agent.isStopped = true;
                enemyController.enemyAnimator.SetFloat("velocity", 0);

                //Look at the Player
                Vector3 targetDir = target.transform.position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(targetDir);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);


                if (enemyController.canAttack)
                {
                    enemyController.enemyAnimator.SetTrigger("basicAttack");
                    enemyController.canAttack = false;
                }

            }
            else //Chasing Player
            {
                enemyController.enemyAnimator.SetFloat("velocity", 1);
                Jumping();
            }

        }
    }

    public void StrongEnemyMovement() {
        if (target != null)
        {
            if (shield)
            {
                enemyController.agent.SetDestination(target.transform.position);

                if ((transform.position - target.transform.position).magnitude < 2) //Attacking
                {
                    //On Range
                    enemyController.agent.isStopped = true;
                    enemyController.enemyAnimator.SetFloat("velocity", 0);

                    //Look at the Player
                    Vector3 targetDir = target.transform.position - transform.position;
                    Quaternion lookRotation = Quaternion.LookRotation(targetDir);
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);


                    if (enemyController.canAttack)
                    {
                        enemyController.enemyAnimator.SetTrigger("basicAttack");
                        enemyController.canAttack = false;
                    }

                }
                else //Chasing Player
                {
                    enemyController.enemyAnimator.SetFloat("velocity", 1);
                    Jumping();
                }
            }
            else 
            {
                float distanceToPlayer = Vector3.Distance(transform.position, target.transform.position);

                Vector3 direction = transform.position - target.transform.position;
                Vector3 destination = transform.position + direction;

                enemyController.agent.SetDestination(destination);
                enemyController.enemyAnimator.SetFloat("velocity", 1);
            }
        }
        else //Out of Range
        {
            enemyController.enemyAnimator.SetFloat("velocity", 0);
            enemyController.agent.SetDestination(transform.position);
        }
    }

    public void MedicEnemyMovement()
    {
        if (target != null)
        {
            enemyController.agent.SetDestination(target.transform.position);

            if ((transform.position - target.transform.position).magnitude < 2) //Heal
            {
                //On Range
                enemyController.agent.isStopped = true;
                enemyController.enemyAnimator.SetFloat("velocity", 0);

                //Look at the dead body
                Vector3 targetDir = target.transform.position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(targetDir);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);

                enemyController.enemyAnimator.SetTrigger("special");

                //Heal the deadBody
                StartCoroutine(Heal());
            }
            else //Moving towards the dead body
            {
                enemyController.enemyAnimator.SetFloat("velocity", 1);
                Jumping();
            }
        }
        else //Out of Range
        {
            enemyController.enemyAnimator.SetFloat("velocity", 0);
            enemyController.agent.SetDestination(transform.position);
        }
    }
    private void Jumping()
    {
        if (enemyController.agent.isOnOffMeshLink && !enemyController.jumped)
        {
            enemyController.enemyAnimator.SetTrigger("jump");
            enemyController.jumped = true;
        }
        else if (!enemyController.agent.isOnOffMeshLink)
        {
            enemyController.jumped = false;
        }
    }

    private IEnumerator RangedCanShoot() 
    {
        canShoot = false;
        yield return new WaitForSecondsRealtime(1f);
        canShoot = true;
    }

    private IEnumerator ResetLaserDetection()
    {
        laser = null;
        laserDetected = false;
        dodgeReset = true;
        yield return new WaitForSecondsRealtime(0.5f);
        dodgeReset = false;
        DodgeBool(false);
    }

    public void DodgeBool(bool active) 
    {
        healthController.dodging = active;
    }

    private IEnumerator Heal() 
    {
        yield return new WaitForSecondsRealtime(4.5f);
        EnemyController targetController = target.GetComponent<EnemyController>();
        targetController.enemyData.currentHealth = targetController.enemyData.maxHealth;
        targetController.enemyAnimator.SetTrigger("Resurrected");
        targetController.dead = false;
        targetController.resurrected = true;
        target = null;
    }
}

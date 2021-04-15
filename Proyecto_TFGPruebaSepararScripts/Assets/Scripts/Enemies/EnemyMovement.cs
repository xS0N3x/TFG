using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyController enemyController;
    public GameObject target;
    public float turnSpeed;
    public LayerMask playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        enemyController = GetComponent<EnemyController>();
        turnSpeed = 5;
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
            float distanceToPlayer = Vector3.Distance(transform.position, target.transform.position);

            Vector3 direction = transform.position - target.transform.position;
            Vector3 destination = transform.position + direction;

            enemyController.agent.SetDestination(destination);
        }
        else
        {
            RaycastHit hit;
            Vector3 rayDirection = target.transform.position - transform.position;
            if (Physics.Raycast(transform.position, rayDirection, out hit, Mathf.Infinity, playerLayer)) 
            {
                print("Disparale al player");
            }
        }
    }

    public void StrongEnemyMovement() { 
    
    }

    public void QuickEnemyMovement() { 
    
    }

    public void MedicEnemyMovement() {
    
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
}

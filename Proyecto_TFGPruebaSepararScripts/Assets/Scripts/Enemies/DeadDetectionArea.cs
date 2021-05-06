using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadDetectionArea : MonoBehaviour
{
    public EnemyMovement movementScript;

    private void Start()
    {
        movementScript = GetComponentInParent<EnemyMovement>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy" && other.GetComponent<EnemyController>().enemyData.currentHealth <= 0)
        {
            //print(other.gameObject);
            if (movementScript.target == null) 
            {
                movementScript.target = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        movementScript.target = null;
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionArea : MonoBehaviour
{
    public EnemyMovement movementScript;

    private void Start()
    {
        movementScript = GetComponentInParent<EnemyMovement>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && other.GetComponent<CapsuleCollider>().enabled)
        {
            //movementScript.agent.SetDestination(other.transform.position);
            movementScript.target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //movementScript.agent.SetDestination(transform.position);
        movementScript.target = null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public EnemyController movementScript;

    private void Start()
    {
        movementScript = GetComponentInParent<EnemyController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && other.GetComponent<CapsuleCollider>().enabled)
        {
            movementScript.agent.SetDestination(other.transform.position);
            movementScript.target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        movementScript.agent.SetDestination(transform.position);
        movementScript.target = null;
    }
}

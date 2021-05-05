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
            movementScript.target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        movementScript.target = null;
        movementScript.StartCoroutine("RangedCanShoot");
    }

    
}

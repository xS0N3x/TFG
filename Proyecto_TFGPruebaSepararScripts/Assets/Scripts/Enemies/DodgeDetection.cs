using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeDetection : MonoBehaviour
{
    public EnemyMovement enemyMovement;

    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = GetComponentInParent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Shoot") 
        {
            enemyMovement.laser = other.gameObject;
            enemyMovement.laserDetected = true;
            enemyMovement.DodgeBool(true);
        }
    }
}

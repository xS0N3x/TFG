using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    public EnemyController enemyController;
    public GameObject shield;

    // Start is called before the first frame update
    void Start()
    {
        enemyController = GetComponentInParent<EnemyController>();
        if (transform.parent.transform.Find("Shield")) 
        {
            shield = transform.parent.transform.Find("Shield").gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            PlayerController playerController = other.GetComponentInParent<PlayerController>();
            PlayerHealth playerHealth = other.GetComponentInParent<PlayerHealth>();

            if (!playerController.blocking)
            {
                playerHealth.TakeDamage(enemyController.enemyData.attackDamage);
            }
            else 
            {
                playerController.playerAudio.PlayOneShot(playerController.blockSound);
                if (shield != null) 
                {
                    shield.SetActive(false);
                    enemyController.hurtArea.SetActive(true);
                    enemyController.enemyMovement.shield = false;
                    StartCoroutine(resetShield());
                } 
            } 

        }
    }

    IEnumerator resetShield() 
    {
        yield return new WaitForSecondsRealtime(6f);
        shield.SetActive(true);
        enemyController.hurtArea.SetActive(false);
        enemyController.enemyMovement.shield = true;
    }
}

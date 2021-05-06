using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private EnemyController enemyController;
    public bool dodging;

    // Start is called before the first frame update
    void Start()
    {
        enemyController = GetComponent<EnemyController>();
        dodging = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage(float amount)
    {
        enemyController.enemyData.currentHealth -= amount;
        if (enemyController.enemyData.currentHealth <= 0)
        {
            enemyController.enemyAnimator.SetTrigger("dead");
            enemyController.dead = true;
            //dodging = true;
        }
        StartCoroutine("GetHurt");

    }

    IEnumerator GetHurt() 
    {
        enemyController.enemyAudio.PlayOneShot(enemyController.hurtSound);
        enemyController.agent.isStopped = true;
        enemyController.enemyAnimator.SetTrigger("hurt");
        enemyController.canAttack = false;
        yield return new WaitForSecondsRealtime(1.5f);
        enemyController.canAttack = true;
        enemyController.agent.isStopped = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{

    public float startingHealth;
    public float currentHealth;
    private Animator enemyAnimator;
    private EnemyController enemyController;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        enemyAnimator = GetComponent<Animator>();
        enemyController = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        currentHealth = currentHealth - amount;
        if (currentHealth <= 0)
        {
            enemyAnimator.SetTrigger("dead");
            enemyController.dead = true;
        }
        StartCoroutine("GetHurt");
    }

    IEnumerator GetHurt() 
    {
        enemyController.agent.isStopped = true;
        enemyAnimator.SetTrigger("hurt");
        enemyController.canAttack = false;
        yield return new WaitForSecondsRealtime(1f);
        enemyController.canAttack = true;
        enemyController.agent.isStopped = false;
    }
}

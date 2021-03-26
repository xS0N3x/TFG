using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{

    public float startingHealth;
    public float currentHealth;
    private Animator enemyAnimator;
    private EnemyController enemyController;
    public AudioSource enemyAudio;
    public AudioClip hurtSound;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        enemyAnimator = GetComponent<Animator>();
        enemyController = GetComponent<EnemyController>();
        enemyAudio = GetComponent<AudioSource>();
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
        enemyAudio.PlayOneShot(hurtSound);
        enemyController.agent.isStopped = true;
        enemyAnimator.SetTrigger("hurt");
        enemyController.canAttack = false;
        yield return new WaitForSecondsRealtime(1.5f);
        enemyController.canAttack = true;
        enemyController.agent.isStopped = false;
    }
}

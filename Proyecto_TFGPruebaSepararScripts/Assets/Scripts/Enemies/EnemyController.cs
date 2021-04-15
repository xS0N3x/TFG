using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [HideInInspector] public EnemyStats enemyData;
    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public Rigidbody enemyRigidbody;
    [HideInInspector] public Animator enemyAnimator;
    public bool jumped;
    public bool dead;
    [HideInInspector] private Collider enemyCollider;
    [HideInInspector] public GameObject target;
    public bool canAttack;
    [HideInInspector] public GameObject hurtArea;
    public int enemyType;
    [HideInInspector] public EnemyMovement enemyMovement;
    [HideInInspector] public AudioSource enemyAudio;
    public AudioClip hurtSound;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyData = enemyData = new EnemyStats(enemyType);
        enemyMovement = GetComponent<EnemyMovement>();
        canAttack = true;
        enemyRigidbody = GetComponent<Rigidbody>();
        enemyAnimator = GetComponent<Animator>();
        enemyCollider = GetComponent<Collider>();
        enemyAudio = GetComponent<AudioSource>();
        jumped = false;
        hurtArea = transform.Find("HurtArea").gameObject;
        agent.speed = enemyData.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            //Al morir bloqueamos el movimiento, la rotación, la velocidad restante y las colisiones.
            agent.isStopped = true;
            enemyRigidbody.freezeRotation = true;
            enemyRigidbody.velocity = Vector3.zero;
            enemyCollider.enabled = false;
            hurtArea.SetActive(false);
        }
        else 
        {
            print(enemyType);
            switch (enemyType) {
                case 0:
                    enemyMovement.BasicEnemyMovement();
                    break;
                case 1:
                    enemyMovement.RangedEnemyMovement();
                    break;
                case 2:
                    enemyMovement.QuickEnemyMovement();
                    break;
                case 3:
                    enemyMovement.StrongEnemyMovement();
                    break;
                case 4:
                    enemyMovement.MedicEnemyMovement();
                    break;
            }
                
        }

    }

    private void resetNavMesh() {
        agent.isStopped = false;
        canAttack = true;
    }
}

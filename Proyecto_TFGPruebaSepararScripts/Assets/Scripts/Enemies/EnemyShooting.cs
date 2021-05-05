using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public EnemyController enemyController;
    public AudioClip laserSound;
    public GameObject laserPrefab;
    private float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyController = GetComponent<EnemyController>();   
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    public void SpawnLaser()
    {
        if (time == 0)
        {
            enemyController.enemyAudio.PlayOneShot(laserSound);
            Instantiate(laserPrefab, enemyController.shootSpawn.transform.position, transform.rotation);
            time = enemyController.enemyData.shootingRatio;
        }
    }

    private void Timer()
    {
        time -= 1 * Time.deltaTime;
        if (time < 0)
        {
            time = 0f;
        }
    }
}

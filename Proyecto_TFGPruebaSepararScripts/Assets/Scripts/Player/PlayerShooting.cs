using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public PlayerController playerController;
    public AudioClip laserSound;
    public GameObject laserPrefab;
    private float time = 0f;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        Timer();
    }

    public void SpawnLaser() 
    {
        if (time == 0)
        {
            playerController.playerAudio.PlayOneShot(laserSound);
            Instantiate(laserPrefab, playerController.shootSpawn.transform.position, transform.rotation);
            time = playerController.playerData.shootingRatio;
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

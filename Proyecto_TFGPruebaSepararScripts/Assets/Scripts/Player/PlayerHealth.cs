using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        if (playerController.blocking && playerController.playerData.currentHealth > 0)
        {
            playerController.playerAudio.PlayOneShot(playerController.blockSound);   
        }
        else if (!playerController.blocking && playerController.playerData.currentHealth > 0)
        {
            playerController.playerData.currentHealth -= amount;
            playerController.playerAudio.volume = 0.1f;
            playerController.playerAudio.PlayOneShot(playerController.hurtSound);
        }

        if (playerController.playerData.currentHealth <= 0) 
        {
            playerController.diing = true;
        }

    }
}

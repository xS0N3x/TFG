using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float startingHealth;
    public float currentHealth;
    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        if (!playerController.blocking)
        {
            currentHealth = currentHealth - amount;
            playerController.playerAudio.volume = 0.1f;
            playerController.playerAudio.PlayOneShot(playerController.hurtSound);
        }
        else 
        {
            playerController.playerAudio.PlayOneShot(playerController.blockSound);
        }
    }
}

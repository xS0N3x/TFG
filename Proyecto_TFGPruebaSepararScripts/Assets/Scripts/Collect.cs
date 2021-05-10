using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerController.playerData.currentHealth < playerController.playerData.maxHealth)
        {
            Destroy(gameObject);
            playerHealth.TakeHealth(20f);
        }
    }
}

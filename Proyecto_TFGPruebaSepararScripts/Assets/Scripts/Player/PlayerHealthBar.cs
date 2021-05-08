using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{

    //public float health;
   // public float maxHealth;
    public Slider slider;
    public PlayerHealth healthController;
    public PlayerController playerController;
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        healthController = player.GetComponent<PlayerHealth>();
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = playerController.playerData.currentHealth / playerController.playerData.maxHealth;
    }

}

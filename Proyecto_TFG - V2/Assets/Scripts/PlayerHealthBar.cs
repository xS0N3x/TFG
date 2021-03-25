using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{

    public float health;
    public float maxHealth;
    public Slider slider;
    public PlayerHealth healthController;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = healthController.startingHealth;
        health = maxHealth;
        slider.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        ControlHealthBar();
    }

    public void ControlHealthBar()
    {
        health = healthController.currentHealth;

        slider.value = CalculateHealth();

        if (health <= 0)
        {
            playerController.diing = true;
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    float CalculateHealth()
    {
        return health / maxHealth;
    }
}

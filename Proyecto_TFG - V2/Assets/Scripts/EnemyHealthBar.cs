using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Slider slider;
    public HealthController healthController;

    private void Start()
    {
        maxHealth = healthController.startingHealth;
        health = maxHealth;
        slider.value = CalculateHealth();
    }

    private void Update()
    {
        ControlHealthBar();
        RotateHealhBar();
    }

    public void ControlHealthBar() 
    {
        health = healthController.currentHealth;

        slider.value = CalculateHealth();

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void RotateHealhBar() 
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.back, Camera.main.transform.rotation * Vector3.up);
    }

    float CalculateHealth() 
    {
        return health / maxHealth;
    }
}

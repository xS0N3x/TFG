using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
    public int moveSpeed;
    public float jumpForce;
    public float shootingRatio;
    public float shotDamage;
    public float attackDamage;
    public float maxHealth;
    public float currentHealth;

    public PlayerStats(int dificultad) 
    {
        if (dificultad == 1)
        {
            moveSpeed = 5;
            jumpForce = 2;
            shootingRatio = 0.25f;
            shotDamage = 8.5f;
            attackDamage = 12;
            maxHealth = 100;
        }
        else 
        {
            moveSpeed = 5;
            jumpForce = 2;
            shootingRatio = 0.25f;
            shotDamage = 8.5f;
            attackDamage = 12;
            maxHealth = 100;
        }

        currentHealth = maxHealth;
    }
}

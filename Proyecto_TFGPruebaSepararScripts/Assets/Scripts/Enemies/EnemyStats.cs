using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats
{
    public float moveSpeed;
    public float attackDamage;
    public float shotDamage;
    public float maxHealth;
    public float currentHealth;
    public float shootingRatio;

    public EnemyStats(int type) 
    {
        if (type == 0) //BasicEnemy 
        {
            moveSpeed = 3;
            attackDamage = 10;
            shotDamage = 0;
            maxHealth = 50;
            
            
        }
        else if (type == 1) //RangedEnemy (Se aleja de ti, solo puedes matarle disparando)
        {
            moveSpeed = 3;
            attackDamage = 0;
            shotDamage = 10;
            maxHealth = 50;
            shootingRatio = 1f;
        }
        else if (type == 2) //QuickEnemy (Te esquiva los disparos)
        {
            moveSpeed = 3;
            attackDamage = 6;
            shotDamage = 0;
            maxHealth = 50;

        }
        else if (type == 3) //StrongEnemy (Tienes que bloquearle o stunearle para poder pegarle)
        {
            moveSpeed = 2;
            attackDamage = 20;
            shotDamage = 0;
            maxHealth = 50;

        }
        else if (type == 4) //MedicEnemy (Cura a los demas enemigos)
        {
            moveSpeed = 3;
            attackDamage = 0;
            shotDamage = 0;
            maxHealth = 50;
        }
        else if (type == 5) //Boss 
        {
            moveSpeed = 3;
            attackDamage = 30;
            shotDamage = 5;
            maxHealth = 10000;
        }

        currentHealth = maxHealth;
    }
}

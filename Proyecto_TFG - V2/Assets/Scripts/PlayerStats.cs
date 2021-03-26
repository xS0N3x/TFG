using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{ 
    [SerializeField] private static int health = 10;


    public static void TakeDamage(int amount) 
    {
        health -= amount;
        if (health <= 0) 
        {
            //he muerto
        }
    }
}

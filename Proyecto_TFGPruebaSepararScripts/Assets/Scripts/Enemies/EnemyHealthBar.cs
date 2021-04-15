using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider slider;
    public HealthController healthController;
    public EnemyController enemyController;

    private void Update()
    {
        RotateHealhBar();
        slider.value = enemyController.enemyData.currentHealth / enemyController.enemyData.maxHealth;
    }

    public void RotateHealhBar() 
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.back, Camera.main.transform.rotation * Vector3.up);
    }
}

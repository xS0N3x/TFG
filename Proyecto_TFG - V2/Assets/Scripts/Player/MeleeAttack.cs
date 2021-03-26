using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public bool attack1, attack2, attack3;
    public static MeleeAttack instance;

    private void Awake()
    {
        instance = this;
    }

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
        if (attack1)
        {
            other.gameObject.transform.parent.GetComponent<HealthController>().TakeDamage(10);
        }
        else if (attack2)
        {
            other.gameObject.transform.parent.GetComponent<HealthController>().TakeDamage(15);
        }
        else 
        {
            other.gameObject.transform.parent.GetComponent<HealthController>().TakeDamage(20);
        }
    }
}

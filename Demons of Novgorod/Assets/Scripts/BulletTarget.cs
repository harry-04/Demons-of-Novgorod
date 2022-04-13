using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTarget : MonoBehaviour
{
    public float enemyHealth;

    //public GameObject target;

    public void Start()
    {
        
    }

    public void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;

        print("damage has been taken");

        if (enemyHealth <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}

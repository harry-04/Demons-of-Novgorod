using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTarget : MonoBehaviour
{
    public float enemyHealth;
    public GameObject enemy;
    public GameObject weapon;

    public GameObject rig;

    Collider[] ragDollColliders;
    Rigidbody[] limbsRigidbodies;


    //public GameObject target;

    public void Start()
    {
        GetRagdollBits();

        RagdollModeOff();

        
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
        //Destroy(enemy);

        RagdollModeOn();

        Destroy(enemy, 5);

        

        //disable weapon
        weapon.SetActive(false);
    }

    void GetRagdollBits()
    {
        ragDollColliders = rig.GetComponentsInChildren<Collider>();
        limbsRigidbodies = rig.GetComponentsInChildren<Rigidbody>();
    }

    void RagdollModeOn()
    {
        foreach (Collider col in ragDollColliders)
        {
            col.enabled = true;
        }

        foreach (Rigidbody rb in limbsRigidbodies)
        {
            rb.isKinematic = false;
        }

        gameObject.GetComponent<Collider>().enabled = false;
        enemy.GetComponent<Animator>().enabled = false;
    }

    void RagdollModeOff()
    {
        foreach (Collider col in ragDollColliders)
        {
            col.enabled = false;
        }

        foreach (Rigidbody rb in limbsRigidbodies)
        {
            rb.isKinematic = true;
        }

        gameObject.GetComponent<Collider>().enabled = true;
        enemy.GetComponent<Animator>().enabled = true;
    }
}

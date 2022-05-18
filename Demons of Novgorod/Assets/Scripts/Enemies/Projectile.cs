using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject impactEffect;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject impact = Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(impact, 2);

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
        }

        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
             col.gameObject.GetComponent<PlayerHealth>().TakeDamage(5);
        }
       
    }
}

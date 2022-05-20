using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HunterJumpArea : MonoBehaviour
{
    public GameObject jumpingHunterObject;


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            jumpingHunterObject.SetActive(true);
            gameObject.SetActive(false);
            
        }
    }
}

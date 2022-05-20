using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HunterJumpScript : MonoBehaviour
{

    public GameObject realHunter;
    public AudioSource jumpSound;
    public AudioSource landSound;

    void OnEnable()
    {
        realHunter.SetActive(false);
        Invoke("BackToChasing", 2);
    }


    public void BackToChasing()
    {
        gameObject.SetActive(false);
        realHunter.transform.position = new Vector3(4.5f, 25.36f, 8.746f);
        realHunter.SetActive(true);
        
    }

    public void Jump()
    {
        jumpSound.Play();
    }

    public void Land()
    {
        landSound.Play();
    }
    
    
}

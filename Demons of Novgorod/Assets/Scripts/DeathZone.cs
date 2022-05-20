using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject theHunter;
    public GameObject phoenix;
    public GameObject musicObject;
    public GameObject hunterJumpArea;
    
    public Animator playeranim;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {

            if (theHunter.activeSelf)
            {
                AudioManager.instance.Play("PatheticMortal");
                theHunter.GetComponent<HunterLines>().enabled = false;

                playeranim.SetTrigger("isDead");
                col.gameObject.GetComponent<CharacterController>().enabled = false;
                col.gameObject.GetComponent<ThirdPersonShooterController>().enabled = false;

                Invoke("ResetPirateDen", 4f);
            }
            else
            {
                col.gameObject.GetComponent<PlayerHealth>().TakeDamage(5);
            }
        }
    
       
    }

    public void ResetPirateDen()
    {
        theHunter.SetActive(false);
        theHunter.transform.position = new Vector3(-20.02191f, 22.12f, 10f);
        theHunter.GetComponent<HunterLines>().enabled = true;
        phoenix.SetActive(false);
        phoenix.transform.position = new Vector3(-48.53f, 22.1f, 24.96f);
        phoenix.SetActive(true);
        phoenix.GetComponent<CharacterController>().enabled = true;
        phoenix.GetComponent<ThirdPersonShooterController>().enabled = true;
        playeranim.SetTrigger("respawn");
        playeranim.ResetTrigger("respawn");
        musicObject.GetComponent<ThePirateDenMusicManager>().BackToShanties();
        hunterJumpArea.SetActive(true);

    }
}

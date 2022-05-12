using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoors : MonoBehaviour
{

    public Vector3 doorLeadsTo;
    public GameObject player;
    public GameObject previousRoom;
    public GameObject nextRoom;
    public GameObject fadeToBlack;

    public AudioSource doorOpenSound;
    public AudioSource doorCloseSound;
    public AudioSource doorLockedSound;

    public GameObject thisDoorIsLockedUI;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider col)
    {
        if (Input.GetKeyDown(KeyCode.E) && player.GetComponent<ThirdPersonShooterController>().hasKey)
        {
            player.GetComponent<CharacterController>().enabled = false;
            doorOpenSound.Play();

            //fade out for 2 seconds
            fadeToBlack.SetActive(true);

            Invoke("NextRoom", 2);
        }
        else if (Input.GetKeyDown(KeyCode.E) && player.GetComponent<ThirdPersonShooterController>().hasKey == false)
        {
            Debug.Log("This door is locked");
            thisDoorIsLockedUI.SetActive(true);
            doorLockedSound.Play();
            Invoke("DisableDoorLockedText", 5f);

        }
        
    }

    void DisableDoorLockedText()
    {
        thisDoorIsLockedUI.SetActive(false);
    }

    public void NextRoom()
    {
        player.transform.position = doorLeadsTo;
        nextRoom.SetActive(true);
        previousRoom.SetActive(false);
        fadeToBlack.SetActive(false);
        player.GetComponent<CharacterController>().enabled = true;
        doorCloseSound.Play();
        Debug.Log("A door has been unlocked");
    }
}

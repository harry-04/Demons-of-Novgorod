using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{

    public Vector3 doorLeadsTo;
    public GameObject player;
    public GameObject previousRoom;
    public GameObject nextRoom;
    public GameObject fadeToBlack;

    public AudioSource doorOpenSound;
    public AudioSource doorCloseSound;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider col)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            player.GetComponent<CharacterController>().enabled = false;
            doorOpenSound.Play();

            //fade out for 2 seconds
            fadeToBlack.SetActive(true);


            Invoke("NextRoom", 2);
        }
    }

    public void NextRoom()
    {
        player.transform.position = doorLeadsTo;
        nextRoom.SetActive(true);
        previousRoom.SetActive(false);
        fadeToBlack.SetActive(false);
        player.GetComponent<CharacterController>().enabled = true;
        doorCloseSound.Play();
        Debug.Log("AKSDNOAINDIOAN");
    }
}

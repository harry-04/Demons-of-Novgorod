using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{

    public Vector3 doorLeadsTo;
    public GameObject player;
    public GameObject previousRoom;
    public GameObject nextRoom;
    
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
            nextRoom.SetActive(true);
            player.transform.position = doorLeadsTo;
            previousRoom.SetActive(false);
            player.GetComponent<CharacterController>().enabled = true;
            Debug.Log("AKSDNOAINDIOAN");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoors : MonoBehaviour
{

    public Vector3 doorLeadsTo;
    public GameObject player;
    public GameObject previousRoom;
    public GameObject nextRoom;

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
            nextRoom.SetActive(true);
            player.transform.position = doorLeadsTo;
            previousRoom.SetActive(false);
            player.GetComponent<CharacterController>().enabled = true;
            Debug.Log("A door has been unlocked");
        }
        else if (Input.GetKeyDown(KeyCode.E) && player.GetComponent<ThirdPersonShooterController>().hasKey == false)
        {
            Debug.Log("This door is locked");
            thisDoorIsLockedUI.SetActive(true);
            Invoke("DisableDoorLockedText", 5f);

        }
        
    }

    void DisableDoorLockedText()
    {
        thisDoorIsLockedUI.SetActive(false);
    }
}

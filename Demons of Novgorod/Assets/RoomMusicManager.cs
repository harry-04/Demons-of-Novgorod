using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMusicManager : MonoBehaviour
{
    public GameObject engineRoom;
    public GameObject corridor;
    public GameObject room303;
    public GameObject cafeteria;
    public GameObject corridor2;
    public GameObject weaponsRoom;

    void Update()
    {
        if (!engineRoom.activeSelf)
        {
            AudioManager.instance.Play("Light Buzz");
        }
    }
}

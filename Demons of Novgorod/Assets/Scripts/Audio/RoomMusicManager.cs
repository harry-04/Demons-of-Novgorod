using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMusicManager : MonoBehaviour
{
    public GameObject engineRoom;
    public GameObject corridor;
    public GameObject room303;


    public GameObject mystery;
    public GameObject engineRoomAreaAmbient;

    void Start()
    {
        mystery.SetActive(false);
        engineRoomAreaAmbient.SetActive(false);
    }

    void Update()
    {
        if (engineRoom.activeSelf)
        {
            engineRoomAreaAmbient.SetActive(false);
            mystery.SetActive(true);
        }
        

        if (corridor.activeSelf)
        {
            mystery.SetActive(false);
            engineRoomAreaAmbient.SetActive(true);
        }

        if (room303.activeSelf)
        {
            engineRoomAreaAmbient.SetActive(false);
            mystery.SetActive(true);
        }
       
       



     
    }
}

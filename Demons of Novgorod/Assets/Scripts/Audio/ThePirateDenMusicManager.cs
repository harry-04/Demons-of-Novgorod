using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThePirateDenMusicManager : MonoBehaviour
{
    public GameObject mainHall;
    public GameObject diningRoom;
    public GameObject corridorToThePirateDen;


    public GameObject mainHallMusic;
    public GameObject diningRoomAmbient;

    void Start()
    {
        mainHallMusic.SetActive(false);
        diningRoomAmbient.SetActive(false);
    }

    void Update()
    {
        if (mainHall.activeSelf)
        {
            diningRoomAmbient.SetActive(false);
            mainHallMusic.SetActive(true);
        }


        if (diningRoom.activeSelf)
        {
            mainHallMusic.SetActive(false);
            diningRoomAmbient.SetActive(true);
        }

        






    }
}

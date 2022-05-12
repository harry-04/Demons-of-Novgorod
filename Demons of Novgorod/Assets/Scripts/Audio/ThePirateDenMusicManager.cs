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
    public GameObject spookyWind;

    void Start()
    {
        mainHallMusic.SetActive(false);
        diningRoomAmbient.SetActive(false);
        spookyWind.SetActive(false);
    }

    void Update()
    {
        if (mainHall.activeSelf)
        {
            spookyWind.SetActive(false);
            diningRoomAmbient.SetActive(false);
            mainHallMusic.SetActive(true);
        }


        if (diningRoom.activeSelf)
        {
            mainHallMusic.SetActive(false);
            diningRoomAmbient.SetActive(true);
        }

        if (corridorToThePirateDen.activeSelf)
        {
            mainHallMusic.SetActive(false);
            spookyWind.SetActive(true);
        }

        






    }
}

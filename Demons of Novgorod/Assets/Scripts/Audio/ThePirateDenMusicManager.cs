using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThePirateDenMusicManager : MonoBehaviour
{
    public GameObject mainHall;
    public GameObject diningRoom;
    public GameObject corridorToThePirateDen;
    public GameObject thePirateDen;
    public GameObject theHunter;
    public GameObject theEndRoom;
    public GameObject door;


    public GameObject mainHallMusic;
    public GameObject diningRoomAmbient;
    public GameObject spookyWind;
    public GameObject seaShanty;
    public GameObject theHunterChaseMusic;

    void Start()
    {
        mainHallMusic.SetActive(false);
        diningRoomAmbient.SetActive(false);
        spookyWind.SetActive(false);
        seaShanty.SetActive(false);
        theHunterChaseMusic.SetActive(false);
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

        if (thePirateDen.activeSelf)
        {
            spookyWind.SetActive(false);
            seaShanty.SetActive(true);    
        }

        if (theHunter.activeSelf)
        {
            door.GetComponent<Doors>().enabled = false;
            seaShanty.SetActive(false);
            theHunterChaseMusic.SetActive(true);
        }

        if (theEndRoom.activeSelf)
        {
            theHunterChaseMusic.SetActive(false);
            mainHallMusic.SetActive(true);
        }

        






    }
}

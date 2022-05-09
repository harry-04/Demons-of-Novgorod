using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject door;
    public GameObject door2;
    public GameObject indicator;
    public GameObject barrier;
    public Material green;

    public void OpenDoor()
    {
        door.GetComponent<Collider>().enabled = true;
        door2.GetComponent<Collider>().enabled = true;
        gameObject.GetComponent<MeshRenderer>().material = green;
        indicator.GetComponent<MeshRenderer>().material = green;
        barrier.SetActive(true);
    }
}

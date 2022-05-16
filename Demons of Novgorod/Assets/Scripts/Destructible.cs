using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject destroyedVersion;

    public GameObject[] bits;

    public GameObject loot;


    public void Shatter()
    {
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        AudioManager.instance.Play("PotBreak");
        if (loot != null)
        {
            loot.SetActive(true);
        }
        Destroy(gameObject);
        GetShatteredBits();
    }

    public void GetShatteredBits()
    {
        bits = GameObject.FindGameObjectsWithTag("DestructibleObject");

        foreach (GameObject bit in bits)
        {
            Destroy(bit, 2);
        }
    }
}

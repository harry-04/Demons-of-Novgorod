using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject destroyedVersion;

    public GameObject bits;


    public void Shatter()
    {
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        AudioManager.instance.Play("PotBreak");
        Destroy(gameObject);
        GetShatteredBits();
        Destroy (bits, 2);
    }

    public void GetShatteredBits()
    {
        //bits = GameObject.FindGameObjectsWithTag("DestructibleObject");
    }
}

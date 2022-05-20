using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterLines : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClipArray;

    AudioSource myAudioSource;

    float timeBetweenLines = 5f;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        timeBetweenLines -= Time.deltaTime;
        if (timeBetweenLines < 0)
        {
            myAudioSource.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
            myAudioSource.PlayOneShot(myAudioSource.clip);
            timeBetweenLines = 5f;
        }
    }
}

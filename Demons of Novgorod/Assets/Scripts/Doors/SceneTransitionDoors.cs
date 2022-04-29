using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionDoors : MonoBehaviour
{
    public string nextLevel;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerStay(Collider col)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
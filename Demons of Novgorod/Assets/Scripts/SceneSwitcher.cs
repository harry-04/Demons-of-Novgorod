using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine(SwitchToEngineRoom());
    }

    IEnumerator SwitchToEngineRoom()
    {
        yield return new WaitForSeconds(35);

        SceneManager.LoadScene("EngineRoom");
    }
}

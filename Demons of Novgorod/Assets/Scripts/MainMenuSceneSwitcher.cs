using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuSceneSwitcher : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("NovgorodBase");
    }

}

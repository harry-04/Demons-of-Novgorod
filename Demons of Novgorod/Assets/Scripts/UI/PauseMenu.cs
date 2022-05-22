using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public AudioSource music;
    public float musicVolume;

    GameObject afterCutscene;
    GameObject ammoManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if (music != null)
        {
            music.pitch = 1f;
            music.volume = musicVolume;
        }
        
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (music != null)
        {
            music.pitch *= 0.5f;
            music.volume *= 0.5f;
        }  
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        afterCutscene = GameObject.FindWithTag("AfterCutscene");
        ammoManager = GameObject.FindWithTag("AmmoManager");
        Destroy(afterCutscene);
        Destroy(ammoManager);
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

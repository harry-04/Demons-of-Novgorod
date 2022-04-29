using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    //create an instance variable of this class so that it doesnt get duplicated on sceneLoad
    private static SceneSwitcher sceneSwitcher;

    bool hasCutscenePlayed;

    public GameObject timeline;
    public GameObject cameraFar;
    public GameObject phoenix;
    public GameObject mainCamera;
    public GameObject playerFollowCamera;

    void Awake()
    {
        

        DontDestroyOnLoad(this.gameObject);

        if (sceneSwitcher == null)
        {
            sceneSwitcher = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        StartCoroutine(SwitchToEngineRoom());
        hasCutscenePlayed = false;
    }

    public void FixedUpdate()
    {
        timeline = GameObject.FindGameObjectWithTag("IntroCutscene");
        cameraFar = GameObject.FindGameObjectWithTag("CameraFar");
        phoenix = GameObject.FindGameObjectWithTag("Player");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        playerFollowCamera = GameObject.FindGameObjectWithTag("PlayerFollowCamera");

        if (hasCutscenePlayed == true)
        {
            Destroy(timeline);
            Destroy(cameraFar);
            mainCamera.SetActive(true);
            playerFollowCamera.SetActive(true);
            phoenix.SetActive(true);

          
        }
    }

    IEnumerator SwitchToEngineRoom()
    {
        yield return new WaitForSeconds(35);

        hasCutscenePlayed = true;
        SceneManager.LoadScene("EngineRoom");
    }
}

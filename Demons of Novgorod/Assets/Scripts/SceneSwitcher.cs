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
    public GameObject boat;
    public GameObject pirate;
    public GameObject ammoInterface;
    public GameObject healthBarInterface;

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
        ammoInterface = GameObject.FindGameObjectWithTag("AmmoUI");
        healthBarInterface = GameObject.FindGameObjectWithTag("HealthUI");
        ammoInterface.SetActive(false);
        healthBarInterface.SetActive(false);
    }

    public void FixedUpdate()
    {
        timeline = GameObject.FindGameObjectWithTag("IntroCutscene");
        cameraFar = GameObject.FindGameObjectWithTag("CameraFar");
        phoenix = GameObject.FindGameObjectWithTag("Player");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        playerFollowCamera = GameObject.FindGameObjectWithTag("PlayerFollowCamera");
        boat = GameObject.FindGameObjectWithTag("Boat");
        pirate = GameObject.FindGameObjectWithTag("Pirate");
        ammoInterface = GameObject.FindGameObjectWithTag("AmmoUI");
        healthBarInterface = GameObject.FindGameObjectWithTag("HealthUI");

        if (hasCutscenePlayed == true)
        {
            Destroy(timeline);
            Destroy(cameraFar);
            Destroy(boat);
            Destroy(pirate);
            mainCamera.SetActive(true);
            playerFollowCamera.SetActive(true);
            phoenix.SetActive(true);
            ammoInterface.SetActive(true);
            healthBarInterface.SetActive(true);
            GetComponent<SceneSwitcher>().enabled = false;

          
        }
    }

    IEnumerator SwitchToEngineRoom()
    {
        yield return new WaitForSeconds(35);

        hasCutscenePlayed = true;
        SceneManager.LoadScene("EngineRoom");
    }
}

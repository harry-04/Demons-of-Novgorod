using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    //create an instance variable of this class so that it doesnt get duplicated on sceneLoad
    private static AmmoManager ammoManager;

    public float loadedAmmoManaged;

    public float overallAmmoManaged;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (ammoManager == null)
        {
            ammoManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        loadedAmmoManaged = 10f;
        overallAmmoManaged = 0f;
    }

    void Update()
    {
        
    }
}

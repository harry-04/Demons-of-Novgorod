using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using StarterAssets;

public class GunScript : MonoBehaviour
{
    public GameObject ammoManager;

    public float loadedAmmo;
    public Text loadedAmmoText;

    public float overallAmmo;
    public Text overallAmmoText;

    public float pistolMagSize = 10;

    private StarterAssetsInputs starterAssetsInputs;

    void Start()
    {
        ammoManager = GameObject.FindWithTag("AmmoManager");
        loadedAmmo = ammoManager.GetComponent<AmmoManager>().loadedAmmoManaged;
        overallAmmo = ammoManager.GetComponent<AmmoManager>().overallAmmoManaged;
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    void Update()
    {
        loadedAmmoText.text = loadedAmmo.ToString();
        overallAmmoText.text = overallAmmo.ToString();

        if (starterAssetsInputs.reload && overallAmmo > 0)
        {
            Reload();
            AudioManager.instance.Play("PistolReload");
            starterAssetsInputs.reload = false;
        }
    }

    public void Reload()
    {

        if (loadedAmmo == 0f)
        {
            loadedAmmo += 10f;
            overallAmmo -= 10f;
            ammoManager.GetComponent<AmmoManager>().loadedAmmoManaged += 10f;
            ammoManager.GetComponent<AmmoManager>().overallAmmoManaged -= 10f;
            starterAssetsInputs.reload = false;
        }


        if (loadedAmmo == 1f)
        {
            loadedAmmo += 9f;
            overallAmmo -= 9f;
            ammoManager.GetComponent<AmmoManager>().loadedAmmoManaged += 9f;
            ammoManager.GetComponent<AmmoManager>().overallAmmoManaged -= 9f;
            starterAssetsInputs.reload = false;
        }


        if (loadedAmmo == 2f)
        {
            loadedAmmo += 8f;
            overallAmmo -= 8f;
            ammoManager.GetComponent<AmmoManager>().loadedAmmoManaged += 8f;
            ammoManager.GetComponent<AmmoManager>().overallAmmoManaged -= 8f;
            starterAssetsInputs.reload = false;
        }


        if (loadedAmmo == 3f)
        {
            loadedAmmo += 7f;
            overallAmmo -= 7f;
            ammoManager.GetComponent<AmmoManager>().loadedAmmoManaged += 7f;
            ammoManager.GetComponent<AmmoManager>().overallAmmoManaged -= 7f;
            starterAssetsInputs.reload = false;
        }


        if (loadedAmmo == 4f)
        {
            loadedAmmo += 6f;
            overallAmmo -= 6f;
            ammoManager.GetComponent<AmmoManager>().loadedAmmoManaged += 6f;
            ammoManager.GetComponent<AmmoManager>().overallAmmoManaged -= 6f;
            starterAssetsInputs.reload = false;
        }


        if (loadedAmmo == 5f)
        {
            loadedAmmo += 5f;
            overallAmmo -= 5f;
            ammoManager.GetComponent<AmmoManager>().loadedAmmoManaged += 5f;
            ammoManager.GetComponent<AmmoManager>().overallAmmoManaged -= 5f;
            starterAssetsInputs.reload = false;
        }



        if (loadedAmmo == 6f)
        {
            loadedAmmo += 4f;
            overallAmmo -= 4f;
            ammoManager.GetComponent<AmmoManager>().loadedAmmoManaged += 4f;
            ammoManager.GetComponent<AmmoManager>().overallAmmoManaged -= 4f;
            starterAssetsInputs.reload = false;
        }


        if (loadedAmmo == 7f)
        {
            loadedAmmo += 3f;
            overallAmmo -= 3f;
            ammoManager.GetComponent<AmmoManager>().loadedAmmoManaged += 3f;
            ammoManager.GetComponent<AmmoManager>().overallAmmoManaged -= 3f;
            starterAssetsInputs.reload = false;
        }


        if (loadedAmmo == 8f)
        {
            loadedAmmo += 2f;
            overallAmmo -= 2f;
            ammoManager.GetComponent<AmmoManager>().loadedAmmoManaged += 2f;
            ammoManager.GetComponent<AmmoManager>().overallAmmoManaged -= 2f;
            starterAssetsInputs.reload = false;
        }

        if (loadedAmmo == 9f)
        {
            loadedAmmo += 1f;
            overallAmmo -= 1f;
            ammoManager.GetComponent<AmmoManager>().loadedAmmoManaged += 1f;
            ammoManager.GetComponent<AmmoManager>().overallAmmoManaged -= 1f;
            starterAssetsInputs.reload = false;
        }

        if (overallAmmo < 0f)
        {
            overallAmmo = 0f;
            ammoManager.GetComponent<AmmoManager>().overallAmmoManaged = 0f;
        }




    }
}

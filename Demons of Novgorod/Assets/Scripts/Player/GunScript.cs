using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using StarterAssets;

public class GunScript : MonoBehaviour
{
    public float loadedAmmo;
    public Text loadedAmmoText;

    public float overallAmmo;
    public Text overallAmmoText;

    public float pistolMagSize = 10;

    private StarterAssetsInputs starterAssetsInputs;

    void Start()
    {
        loadedAmmo = 10f;
        overallAmmo = 0f;
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
            starterAssetsInputs.reload = false;
        }


        if (loadedAmmo == 1f)
        {
            loadedAmmo += 9f;
            overallAmmo -= 9f;
            starterAssetsInputs.reload = false;
        }


        if (loadedAmmo == 2f)
        {
            loadedAmmo += 8f;
            overallAmmo -= 8f;
            starterAssetsInputs.reload = false;
        }


        if (loadedAmmo == 3f)
        {
            loadedAmmo += 7f;
            overallAmmo -= 7f;
            starterAssetsInputs.reload = false;
        }


        if (loadedAmmo == 4f)
        {
            loadedAmmo += 6f;
            overallAmmo -= 6f;
            starterAssetsInputs.reload = false;
        }


        if (loadedAmmo == 5f)
        {
            loadedAmmo += 5f;
            overallAmmo -= 5f;
            starterAssetsInputs.reload = false;
        }



        if (loadedAmmo == 6f)
        {
            loadedAmmo += 4f;
            overallAmmo -= 4f;
            starterAssetsInputs.reload = false;
        }


        if (loadedAmmo == 7f)
        {
            loadedAmmo += 3f;
            overallAmmo -= 3f;
            starterAssetsInputs.reload = false;
        }


        if (loadedAmmo == 8f)
        {
            loadedAmmo += 2f;
            overallAmmo -= 2f;
            starterAssetsInputs.reload = false;
        }

        if (loadedAmmo == 9f)
        {
            loadedAmmo += 1f;
            overallAmmo -= 1f;
            starterAssetsInputs.reload = false;
        }

        if (overallAmmo < 0f)
        {
            overallAmmo = 0f;
        }




    }
}

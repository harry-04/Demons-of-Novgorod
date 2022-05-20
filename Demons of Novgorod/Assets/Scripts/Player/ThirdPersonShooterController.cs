using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;

    //bullet impact effects
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;

    //grenade variables
    public float throwForce = 40f;
    public GameObject grenadePrefab;
    public Transform grenadePoint;

    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;

    private Animator animator;

    public GameObject pistol;
    public GameObject crosshair;
    private float damage;
    private bool canShoot;

    public float fireRate = 15f;
    private float nextTimeToFire = 0f;

    public bool hasKey;

    //footstep sound effect
    public AudioSource footstep;



    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
        damage = 5f;
        canShoot = false;
        hasKey = false;
    }

    private void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);

        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        Transform hitTransform = null;
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
            hitTransform = raycastHit.transform;
        }

       

        if (starterAssetsInputs.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(false);
            
            //since the aiming animation is on a different layer, we set the layer weight to 1 (since it goes up by 0,1,2,3, etc.)
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));
            pistol.SetActive(true);
            crosshair.SetActive(true);
            canShoot = true;

            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);

           
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotateOnMove(true);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
            pistol.SetActive(false);
            crosshair.SetActive(false);
            canShoot = false;
            starterAssetsInputs.shoot = false;
        }

        
        if (starterAssetsInputs.shoot && canShoot == true && gameObject.GetComponent<GunScript>().loadedAmmo > 0 && Time.time >= nextTimeToFire)
        {
            if (hitTransform != null)
            {
                //if its not null, then we hit a target
                if (hitTransform.GetComponent<BulletTarget>() != null)
                {
                    BulletTarget bulletTarget = hitTransform.GetComponent<BulletTarget>();

                    //Hit target
                    Instantiate(vfxHitGreen, raycastHit.point, Quaternion.identity);
                    bulletTarget.TakeDamage(damage);
                }
                else
                {
                    //Hit a non-target
                    Instantiate(vfxHitRed, raycastHit.point, Quaternion.identity);
                }



                if (hitTransform.GetComponent<ButtonScript>() != null)
                {
                    ButtonScript buttonScript = hitTransform.GetComponent<ButtonScript>();

                    //Activate button
                    Instantiate(vfxHitGreen, raycastHit.point, Quaternion.identity);
                    buttonScript.OpenDoor();
                }

                if (hitTransform.GetComponent<Destructible>() != null)
                {
                    Destructible destructible = hitTransform.GetComponent<Destructible>();

                    Instantiate(vfxHitGreen, raycastHit.point, Quaternion.identity);
                    destructible.Shatter();
                }



            }

            nextTimeToFire = Time.time + 1f / fireRate;
            animator.SetTrigger("canShoot");
            AudioManager.instance.Play("Gunshot");
            starterAssetsInputs.shoot = false;
            gameObject.GetComponent<GunScript>().loadedAmmo --;
        }

        
        if (starterAssetsInputs.interact)
        {
            //check for interactable object
            if (Physics.Raycast(ray, out raycastHit, 6))
            {
                HandgunAmmo handgunAmmo = raycastHit.collider.GetComponent<HandgunAmmo>();
                KeyScript keyScript = raycastHit.collider.GetComponent<KeyScript>();

                if (handgunAmmo != null)
                {
                    gameObject.GetComponent<GunScript>().overallAmmo += 10;
                    AudioManager.instance.Play("PickUpAmmo");
                    Destroy(hitTransform.gameObject);
                    starterAssetsInputs.interact = false;
                }

                if (keyScript != null)
                {
                    hasKey = true;
                    Destroy(hitTransform.gameObject);
                    starterAssetsInputs.interact = false;
                }
            }
        }

        if (starterAssetsInputs.throwgrenade && canShoot)
        {
            animator.SetTrigger("canThrowGrenade");
            starterAssetsInputs.throwgrenade = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            AudioManager.instance.Play("PistolAim");
        }

    }

    public void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, grenadePoint.position, grenadePoint.rotation);

        //apply a forward force to the grenade
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }

    public void DisableHandGun()
    {
        pistol.transform.position = new Vector3(-100, -100, -100);
    }

    public void EnableHandgun()
    {
        pistol.transform.position = new Vector3(0, 0, 0);
    }

    public void Footstep()
    {
        footstep.Play();
    }

    

    


}

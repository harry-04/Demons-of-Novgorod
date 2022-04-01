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

    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;

    private Animator animator;

    public GameObject pistol;
    public GameObject crosshair;
    private float damage;
    private bool canShoot;


    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
        damage = 5f;
        canShoot = false;
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
        }

        
        if (starterAssetsInputs.shoot && canShoot == true && gameObject.GetComponent<GunScript>().loadedAmmo > 0)
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
            }

            animator.SetTrigger("canShoot");
            starterAssetsInputs.shoot = false;
            gameObject.GetComponent<GunScript>().loadedAmmo --;
        }

        
        if (starterAssetsInputs.interact)
        {
            //check for interactable object
            if (Physics.Raycast(ray, out raycastHit, 100))
            {
                HandgunAmmo handgunAmmo = raycastHit.collider.GetComponent<HandgunAmmo>();

                if (handgunAmmo != null)
                {
                    gameObject.GetComponent<GunScript>().overallAmmo += 10;
                    Destroy(hitTransform.gameObject);
                    starterAssetsInputs.interact = false;
                }
            }
        }

    }



    


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuchWater : MonoBehaviour
{
    public GameObject phoenix;
    public Animator phoenixAnim;

    void Awake()
    {
        Cursor.visible = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            phoenixAnim.SetTrigger("isDead");
            phoenix.GetComponent<CharacterController>().enabled = false;
            phoenix.GetComponent<ThirdPersonShooterController>().enabled = false;

            Invoke("ResetNovgorodBase", 4);
        }


    }

    public void ResetNovgorodBase()
    {
        phoenix.SetActive(false);
        phoenix.transform.position = new Vector3(-23.84f, 7.89f, 23.476f);
        phoenix.SetActive(true);

        phoenix.GetComponent<CharacterController>().enabled = true;
        phoenix.GetComponent<ThirdPersonShooterController>().enabled = true;
        phoenixAnim.SetTrigger("respawn");
        phoenixAnim.ResetTrigger("respawn");

    }
}

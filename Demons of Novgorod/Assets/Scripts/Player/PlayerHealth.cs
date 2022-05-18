using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public HealthBar healthBar;

    public Animator anim;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        anim.SetTrigger("isDead");
        gameObject.GetComponent<CharacterController>().enabled = false;
        gameObject.GetComponent<ThirdPersonShooterController>().enabled = false;

        FindObjectOfType<GameManager>().EndGame();
    }
}

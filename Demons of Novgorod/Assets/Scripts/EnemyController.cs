using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public float attackRadius;

    public Animator animator;

    Transform target;
    NavMeshAgent agent;

    public AudioSource footstep1;
    public AudioSource footstep2;


    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        //InvokeRepeating("RandomSounds", 5, 5);

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            animator.SetBool("isWalking", true);

            if (distance <= agent.stoppingDistance)
            {
                //attack the target
                

                //face the target
                FaceTarget();
            }
           
        }
        else
        {
            animator.SetBool("isWalking", false);
        }


        if (distance <= attackRadius)
        {
            animator.SetBool("canAttack", true);
        }
        else
        {
            animator.SetBool("canAttack", false);
        }

    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    public void FootstepLeft()
    {
        footstep1.Play();
    }

    public void FootstepRight()
    {
        footstep2.Play();
    }

   
}

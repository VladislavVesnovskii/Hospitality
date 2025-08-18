using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Doctor : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator animator;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealthComponent>().TakeDamage(1);
            return;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cage"))
        {
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            animator.SetTrigger("CageCapture");
        }
    }
}

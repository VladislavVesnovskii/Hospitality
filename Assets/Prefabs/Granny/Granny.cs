using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granny : MonoBehaviour
{
    [SerializeField] Collider colliderG;
    [SerializeField] Animator animator;
    public int Health;
    

    void Start()
    {

       animator = GetComponent<Animator>();

    }

    public void ColliderON()
    {
        colliderG.enabled = true;
    }
    public void ColliderOFF()
    {
        colliderG.enabled=false;
    }

    public void Damage(int damage)
    {
        Health -= damage;
        if (Health <= 0) 
        {
            animator.SetBool("isDying", true);
        }
    }


}

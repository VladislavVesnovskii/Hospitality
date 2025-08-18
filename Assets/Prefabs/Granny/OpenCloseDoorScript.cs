using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseDoorScript : MonoBehaviour
{
    public Animator animator;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Granny>() || other.gameObject.GetComponent<Doctor>())
        {
            animator.SetBool("DoorOn", true);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Granny>()|| other.gameObject.GetComponent<Doctor>())
        {
            animator.SetBool("DoorOn", false);
        }
    }
}

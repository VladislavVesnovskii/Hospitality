using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class Door : MonoBehaviour
{
    public Animator animator;
    [SerializeField] int triggerID;
    [SerializeField] Transform player;
    BoxCollider bc;
    [SerializeField] AudioSource AC;
    [SerializeField] AudioClip ac;

    public void OnEnable()
    {
        bc = gameObject.GetComponent<BoxCollider>();
        EventBus.EventOn += OpenTheDoor;
    }

    public void OnDisable()
    {
        EventBus.EventOn -= OpenTheDoor;
    }

    public void OpenTheDoor(int triggerID)
    {
        if (this.triggerID == triggerID && Vector3.Distance(transform.position, player.position)<=2.5f)
        {
            animator.SetBool("DoorOn", true);  
            bc.enabled = false;
            AC.PlayOneShot(ac);

        }      
    }
    public void OpenSimpleDoor()
    {
        animator.SetBool("DoorOn", true);
        bc.enabled = false;
        if (FindObjectOfType<Bell>().alarmOff == false)
        {
            FindObjectOfType<Bell>().ToMakeAlarmON();
        }
        else
        {
            Debug.Log("Alarm OFF");
        }
    }
}

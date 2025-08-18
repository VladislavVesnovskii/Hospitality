using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Slider : MonoBehaviour
{
    public Animator animator;
    public Animator cellAnimator;
    [SerializeField] int triggerID;
    [SerializeField] AudioSource AC;
    [SerializeField] AudioClip slider;
    [SerializeField] AudioClip door;

    public void OnEnable()
    {
        EventBus.EventOn += OpenSlider;
    }
    public void OnDisable()
    {
        EventBus.EventOn -= OpenSlider;
    }

    public void OpenSlider(int triggerID)
    {
        if (this.triggerID == triggerID)
        {
            animator.SetBool("SliderOn", true);
            AC.PlayOneShot(slider);
        }

    }
    public void OpenDoor()
    {
        cellAnimator.SetTrigger("DoorIsOpen");
        AC.PlayOneShot(door);
    }

}

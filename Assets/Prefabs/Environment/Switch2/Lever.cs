using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    [SerializeField] bool leverCondition;
    [SerializeField] Animator leverAnimator;
    [SerializeField] AudioSource AC;
    [SerializeField] AudioClip ac;

    public void LeverPosition()
    {
        if (!leverCondition)
        {
            leverAnimator.SetBool("Lever", true);
            leverCondition = true;
            EventBus.LiftOn?.Invoke(leverCondition);
            AC.PlayOneShot(ac);
            
        }
        else
        {
            leverAnimator.SetBool("Lever", false);
            leverCondition= false;
            EventBus.LiftOn?.Invoke(leverCondition);
            AC.PlayOneShot(ac);
        }
    }
}

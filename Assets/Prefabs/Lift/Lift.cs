using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{

    [SerializeField] bool liftIsON;
    [SerializeField] Animator liftAnimator;
    [SerializeField] AudioSource AC;
    [SerializeField] AudioClip ac;

    void Start()
    {
        EventBus.LiftOn += MakeButtonsON;
        EventBus.LiftLift += LiftLift;
        EventBus.DecentLift += DecentLift;
    }
    public void LiftLift()
    {
        if (liftIsON)
        {
            liftAnimator.SetBool("Lift", true);
            AC.PlayOneShot(ac);
        }
    }

    public void DecentLift()
    {
        if (liftIsON)
        {
            liftAnimator.SetBool("Lift", false);
            AC.PlayOneShot(ac);
        }

    }
    public void MakeButtonsON (bool condition)
    {
        liftIsON = condition;
    }
}

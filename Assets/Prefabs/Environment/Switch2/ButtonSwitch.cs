using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitch : MonoBehaviour
{
    [SerializeField] Animator buttonAnimator;
    [SerializeField] MeshRenderer button1;
    [SerializeField] MeshRenderer button2;
    [SerializeField] AudioSource AC;
    [SerializeField] AudioClip ac;
  
    void Start()
    {
        //EventBus.LiftOn += LitButtons;
    }

    public void LiftButton()
    {

        buttonAnimator.SetBool("Lift",true);
        AC.PlayOneShot(ac);
        EventBus.LiftLift?.Invoke();
    }
    public void DecentButton()
    {
        buttonAnimator.SetBool("Lift", false);
        AC.PlayOneShot(ac);
        EventBus.DecentLift?.Invoke();
    }

    //public void LitButtons(bool condition)
    //{
    //    if (condition)
    //    {
    //        button1.material.EnableKeyword("_EMISSION");
    //        button2.material.EnableKeyword("_EMISSION");
    //    }
    //    else 
    //    {
    //        button1.material.DisableKeyword("_EMISSION");
    //        button2.material.DisableKeyword("_EMISSION");
    //    }
    //}
}

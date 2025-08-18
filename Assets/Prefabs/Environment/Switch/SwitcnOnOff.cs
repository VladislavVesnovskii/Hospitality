using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcnOnOff : MonoBehaviour
{
    public int switchIndex;
    public bool switchCondition;
    public Animator switchAnimator;
    Switch switchGO;
    [SerializeField] AudioSource AC;
    [SerializeField] AudioClip ac;
    private void Start()
    {
        switchIndex = transform.GetSiblingIndex();
        switchGO = gameObject.transform.parent.GetComponent<Switch>();
    }

    public void SwitchPosition()
    {
        if (!switchCondition)
        {
            
            switchCondition = true;
            switchGO.SetSwitchCondition(switchIndex, switchCondition);
            switchAnimator.SetTrigger("SwitchDown");
            AC.PlayOneShot(ac);
        }
        else
        {
            switchCondition = false;
            switchGO.SetSwitchCondition(switchIndex, switchCondition);
            switchAnimator.SetTrigger("SwitchUp");
            AC.PlayOneShot(ac);
        }
    }

}

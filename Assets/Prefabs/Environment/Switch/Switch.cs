using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour
{

    public List<bool> switches = new List<bool>();
    public Animator cageAnimator;
    BoxCollider boxCollider;

    private void Start()
    {
        boxCollider = cageAnimator.transform.GetChild(0).GetComponent<BoxCollider>();
    }
    public void DecentCage()
    {
        if (!switches[0] && switches[1] && !switches[2] && switches[3] && switches[4])
        {
            cageAnimator.SetBool("Up", false);
            Debug.Log("Decent the cage");
            boxCollider.enabled = true;
            return;
        }
        else
        {
            cageAnimator.SetBool("Up", true);
            boxCollider.enabled = false;
            Debug.Log("Lift the cage");

        }
    }

    public void SetSwitchCondition(int switchIndex, bool switchBool)
    {
        switches[switchIndex] = switchBool;
        DecentCage();
    }

}

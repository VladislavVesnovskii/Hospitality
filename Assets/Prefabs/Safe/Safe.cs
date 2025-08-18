using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour
{
    [SerializeField] int triggerID;
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider boxCollider;
    void OpenSafe(int triggerID)
    {
        if(this.triggerID == triggerID)
        {
            animator.SetBool("Open", true);
            boxCollider.enabled = false;
        }
    }
    public void OnEnable()
    {
        EventBus.EventOn += OpenSafe;
    }

    public void OnDisable()
    {
        EventBus.EventOn -= OpenSafe;
    }
}

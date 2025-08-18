using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
    [SerializeField] int triggerID;
    [SerializeField] Animator doubleDoorAniator;
    [SerializeField] AudioSource AC;
    [SerializeField] AudioClip ac;
    [SerializeField] BoxCollider boxCollider;


    public void OnEnable()
    {
        EventBus.EventOn += ChainReaction;
    }
    public void OnDesable()
    {
        EventBus.EventOn -= ChainReaction;
    }
    void ChainReaction(int triggerID)
    {
        if(this.triggerID == triggerID)
        {
            DeleteChain();
            OpenDoubleDoor();
            Destroy(gameObject);
        }
    }

    void DeleteChain()
    {
        AC.PlayOneShot(ac);
    }
    void OpenDoubleDoor()
    {
        doubleDoorAniator.SetBool("Open", true);
        boxCollider.enabled = false;
    }
}

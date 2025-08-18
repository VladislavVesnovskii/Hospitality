using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    [SerializeField] int triggerID;
    [SerializeField] GameObject questItemPoint;
    [SerializeField] Transform monkeyHand;
    [SerializeField] Transform keyPlace;
    [SerializeField] GameObject key;
    [SerializeField] GameObject apple;
    [SerializeField] Animator animator;
    [SerializeField] Transform cellConteiner;

    public void MonkeyReaction(int triggerID)
    {
        if (this.triggerID == triggerID)
        {
            animator.SetBool("GotApple", true);
            MonkeyDropKey();
            GiveApple();
            RemoveIconFromInventory();     
        }
    }
    
    void RemoveIconFromInventory()
    {
        for (int i = 0; i < cellConteiner.childCount; i++)
        {
            PanelInventyCell pic = cellConteiner.GetChild(i).gameObject.GetComponent<PanelInventyCell>();
            if (pic.takenItemID == triggerID)
            {
                pic.takenItemID = 0;
                pic.takenPrefab = null;
                pic.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Image>().sprite = null;

            }
        }
    }
    void MonkeyDropKey()
    {
        monkeyHand.GetChild(0).gameObject.transform.SetParent(keyPlace);
        key.transform.localPosition = Vector3.zero;
        key.transform.localRotation = Quaternion.identity;
        key.transform.localScale = Vector3.one*40;
        key.GetComponent<BoxCollider>().enabled = true;
    }
    void GiveApple()
    {
        questItemPoint.transform.GetChild(0).gameObject.transform.SetParent(monkeyHand);
        apple.transform.localPosition = Vector3.zero;
        apple.transform.localRotation = Quaternion.identity;
        apple.transform.localScale = Vector3.one;
        apple.GetComponent<SphereCollider>().enabled = false;
    }

    public void OnEnable()
    {
        EventBus.EventOn += MonkeyReaction;
    }
    public void OnDisable()
    {
        EventBus.EventOn -= MonkeyReaction;
    }

}

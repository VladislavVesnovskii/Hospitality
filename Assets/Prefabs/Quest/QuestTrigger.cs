using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    [SerializeField] GameObject questItemPoint;
    [SerializeField] int triggerID;
    [SerializeField] GameObject signPanel;
    [SerializeField] TextMeshProUGUI textPanel;
    public string sign1;
    public string sign2;
    public string sign3;


    public void CheckCurrentItem()
    {
        if (questItemPoint.transform.childCount != 0)
        {
            if (questItemPoint.transform.GetChild(0).GetComponent<Item>().id == triggerID)
            {
                CallEvent();
                return;
            }
            else
            {
                signPanel.SetActive(true);
                IncorrectTrigger();
                StartCoroutine(InactivatePanel());
            }
        }
        else
        {
            signPanel.SetActive(true);
            NoTrigger();
            StartCoroutine(InactivatePanel());
        }
    }

    public void IncorrectTrigger()
    {
        textPanel.text = sign1;
    }
    public void NoTrigger()
    {
        textPanel.text = sign2;
    }

    IEnumerator InactivatePanel()
    {
        yield return new WaitForSeconds(3f);
        textPanel.text = sign3;
        signPanel.SetActive(false);
        StopCoroutine(InactivatePanel());
    }


    public void CallEvent()
    {
        EventBus.EventOn?.Invoke(triggerID);
    }

}

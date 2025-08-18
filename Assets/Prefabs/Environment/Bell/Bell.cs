using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bell : MonoBehaviour
{
    [SerializeField] int triggerID;
    [SerializeField] GameObject questItemPoint;
    [SerializeField] Transform bubleGumPosition;
    public bool alarmOff;
    public Inventory inventory;
    [SerializeField] Transform granny;
    [SerializeField] NavMeshAgent NMAGranny;
    [SerializeField] Transform grannyAlarmPosition;

    public void OnEnable()
    {
        EventBus.EventOn += MakeBellOff;
    }

    public void OnDisable()
    {
        EventBus.EventOn -= MakeBellOff;
    }

    public void MakeBellOff(int triggerID)
    {
        if (this.triggerID == triggerID)
        {
            GameObject go = gameObject.transform.GetChild(0).gameObject;
            questItemPoint.transform.GetChild(0).gameObject.transform.parent = go.transform;
            GameObject go1 = go.transform.GetChild(0).gameObject;
            go1.transform.localPosition = Vector3.zero;
            go1.transform.localRotation = Quaternion.identity;
            go1.GetComponent<SphereCollider>().enabled = false;
            alarmOff = true;
            for (int i = 0; i < inventory.cellContainer.transform.childCount; i++)
            {
                PanelInventyCell pic = inventory.cellContainer.transform.GetChild(i).gameObject.GetComponent<PanelInventyCell>();
                if (pic.takenItemID == triggerID)
                {
                    pic.takenItemID = 0;
                    pic.takenPrefab = null;
                    pic.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Image>().sprite = null;
                }
            }
        }      
    }
    public void ToMakeAlarmON()
    {
        GetComponent<AudioSource>().Play();
        ChaseBehaviour.chaseRange = 1000f;
        NMAGranny.enabled = false;
        granny.transform.position = grannyAlarmPosition.position;
        NMAGranny.enabled = true;
        //StartCoroutine(Kostil());
        granny.GetComponent<Animator>().SetBool("isChasing", true);
    }

    //IEnumerator Kostil()
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    float currentDistance = Vector3.Distance(gameObject.transform.position, granny.transform.position);
    //    float setDistance = Vector3.Distance(gameObject.transform.position, grannyAlarmPosition.position);
    //    if (currentDistance >= setDistance)
    //    {
    //        granny.transform.position = grannyAlarmPosition.position;
    //    }
    //    NMAGranny.enabled = true;
    //}

}

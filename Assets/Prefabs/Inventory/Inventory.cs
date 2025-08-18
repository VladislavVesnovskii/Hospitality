using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
//using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

[System.Serializable]
public class Inventory : MonoBehaviour
{
    [SerializeField] List<GameObject> items= new List<GameObject>();
    public Dictionary<int,GameObject> prefabDictionary;
    public GameObject cellContainer;
    public GameObject point;
    public Transform questItemPoint;
    public Transform flashLightPoint;
    [SerializeField] FlashLight FL;
    [SerializeField] GameObject FLButton;
    public Transform wareHousePosition;
    public GameObject itemInformationPanel;
    [SerializeField] float rayDistance = 2;
    public GameObject currentItem;
    public GameObject pictureArea;
    public GameObject textArea;
    public bool grannyIsShooted;
    [SerializeField] int damageRate;
    public int amt;
    public SetLanguage SL;
    void Start()
    {
        BeginGame();
    }

    public void BeginGame()
    {
        prefabDictionary = new Dictionary<int,GameObject>();
        prefabDictionary.Add(1, items[0]);
        prefabDictionary.Add(2, items[1]);
        prefabDictionary.Add(6, items[2]);
        prefabDictionary.Add(44, items[3]);
        prefabDictionary.Add(5, items[4]);
        prefabDictionary.Add(7, items[5]);
        prefabDictionary.Add(13, items[6]);
        prefabDictionary.Add(14, items[7]);
        prefabDictionary.Add(21, items[8]);
        prefabDictionary.Add(23, items[9]);
        prefabDictionary.Add(18, items[10]);

        for (int i = 0; i < cellContainer.transform.childCount; i++)
        {
            cellContainer.transform.GetChild(i).GetComponent<PanelInventyCell>().itemIndex = i;
        }
        cellContainer.SetActive(false);
        questItemPoint = GameObject.FindGameObjectWithTag("QuestItemPoint").transform;
        flashLightPoint = GameObject.FindGameObjectWithTag("FlashlightPoint").transform;
        EventBus.OnLoadGame?.Invoke();
        SL.SetGameLanguage();
    }



    

    public void AddItemToInventory()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        rayDistance = 100f;
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (questItemPoint.transform.childCount != 0)
            {
                if (questItemPoint.transform.GetChild(0).tag == "Revolver" && !hit.collider.gameObject.GetComponent<Item>())
                {
                        questItemPoint.transform.GetChild(0).GetComponent<Gun>().Shot(Gun.ShotBehavior.shot);
                        grannyIsShooted = true;
                        if (hit.collider.gameObject.CompareTag("Granny"))
                        {
                        hit.collider.gameObject.GetComponent<Granny>().Damage(damageRate);
                        }
                }
            }
        }
        rayDistance = 2f;
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.GetComponent<Item>())
            {
                hit.collider.gameObject.layer = 7;
                for (int i = 0; i < cellContainer.transform.childCount; i++)
                {
                    if (cellContainer.transform.GetChild(i).gameObject.GetComponent<PanelInventyCell>().takenItemID == 0 && hit.collider.GetComponent<Item>().isStackable)
                    {
                        GameObject go = cellContainer.transform.GetChild(i).gameObject;
                        Item item = hit.collider.GetComponent<Item>();
                        go.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = item.icon;
                        go.GetComponent<PanelInventyCell>().takenItemID = item.id;
                            amt++;
                        go.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = amt.ToString();
                            itemInformationPanel.SetActive(true);
                            item.transform.position = wareHousePosition.position;
                            itemInformationPanel.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = item.icon;
                            itemInformationPanel.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = item.descriptionItem;
                            StartCoroutine(CloseItemInformationPanel());
                            break;
                    }
                    else if (cellContainer.transform.GetChild(i).gameObject.GetComponent<PanelInventyCell>().takenItemID == hit.collider.GetComponent<Item>().id && hit.collider.GetComponent<Item>().isStackable)
                    {
                        GameObject go = cellContainer.transform.GetChild(i).gameObject;
                        Item item = hit.collider.GetComponent<Item>();
                        amt++;
                        go.GetComponent<PanelInventyCell>().takenItemID =
                        item.id;
                        go.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = amt.ToString();
                        itemInformationPanel.SetActive(true);
                        item.transform.position = wareHousePosition.position;
                        itemInformationPanel.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = item.icon;
                        itemInformationPanel.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = item.descriptionItem;
                        StartCoroutine(CloseItemInformationPanel());
                        break;
                    }
                    

                    if (cellContainer.transform.GetChild(i).gameObject.GetComponent<PanelInventyCell>().takenItemID == 0 && !hit.collider.GetComponent<Item>().isStackable)
                    {
                        GameObject go = cellContainer.transform.GetChild(i).gameObject;
                        Item item = hit.collider.GetComponent<Item>();
                        go.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = item.icon;
                        go.GetComponent<PanelInventyCell>().takenItemID = item.id;
                        currentItem = item.gameObject;
                        go.GetComponent<PanelInventyCell>().takenPrefab = item.gameObject;
                        item.transform.position = wareHousePosition.position;
                        itemInformationPanel.SetActive(true);
                        itemInformationPanel.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = item.icon;
                        itemInformationPanel.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = item.descriptionItem;
                        StartCoroutine(CloseItemInformationPanel());
                        break;
                    }
                }
            }
            else if (hit.collider.gameObject.GetComponent<QuestTrigger>())
            {
                hit.collider.gameObject.GetComponent<QuestTrigger>().CheckCurrentItem();
                return;
            }
            else if (hit.collider.gameObject.CompareTag("Door"))
            {
                hit.collider.gameObject.GetComponent<Door>().OpenSimpleDoor();
                return;
            }
            else if (hit.collider.gameObject.CompareTag("Switch"))
            {
                hit.collider.gameObject.GetComponent<SwitcnOnOff>().SwitchPosition();
                return;
            }
            else if (hit.collider.gameObject.CompareTag("Lever"))
            {
                hit.collider.gameObject.GetComponent <Lever>().LeverPosition();
                return;
            }
            else if (hit.collider.gameObject.CompareTag("Button1"))
            {
                hit.collider.gameObject.transform.parent.GetComponent<ButtonSwitch>().LiftButton();
                return;
            }
            else if (hit.collider.gameObject.CompareTag("Button2"))
            {
                hit.collider.gameObject.transform.parent.GetComponent<ButtonSwitch>().DecentButton();
                return;
            }

        }



    }
    public void ToggleInventory()
    {
            if (cellContainer.activeSelf)
            {
                cellContainer.SetActive(false);
                point.SetActive(true);
                Time.timeScale = 1.0f;
            }
            else
            {
                cellContainer.SetActive(true);
                point.SetActive(false);
            Time.timeScale = 0;
            }
    }



    IEnumerator CloseItemInformationPanel()
    {
        yield return new WaitForSeconds(3f);
        itemInformationPanel.SetActive(false);
        StopCoroutine(CloseItemInformationPanel());
    }

    public void ShowTakenItem(int value, GameObject go)
    {
        if (questItemPoint.transform.childCount > 0)
        {
            for (int i = 0; i < questItemPoint.transform.childCount; i++)
            {
                Transform questItem = questItemPoint.transform.GetChild(i).gameObject.transform;
                questItem.position = wareHousePosition.position;
                questItem.parent = wareHousePosition.transform;
            }
            currentItem = go;
            currentItem.GetComponent<Item>().isShown = true;
            currentItem.transform.parent = questItemPoint.transform;
            currentItem.transform.localPosition = new Vector3(0, 0, 0);
            currentItem.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            if (currentItem.CompareTag("Revolver"))
            {
                currentItem.transform.localEulerAngles = new Vector3(-10f, 115f, -5f);
                cellContainer.SetActive(false);
                return;
            }
            if (currentItem.CompareTag("File"))
            {
                currentItem.transform.localEulerAngles = new Vector3(-150f, 150f, -100f);
                cellContainer.SetActive(false);
                return;
            }
            if (currentItem.gameObject.CompareTag("Flashlight"))
            {
                FLButton.SetActive(true);
                FL.isHaveFlashlight = true;
                currentItem.transform.parent = flashLightPoint.transform;
                currentItem.transform.localPosition = new Vector3(0, 0, 0);
                currentItem.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                cellContainer.SetActive(false);
                return;
            }
        }
        
        else
        {
            currentItem = go;
            currentItem.GetComponent<Item>().isShown = true;
            currentItem.transform.parent = questItemPoint.transform;
            currentItem.transform.localPosition = new Vector3(0, 0, 0);
            currentItem.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            if (currentItem.CompareTag("Revolver"))
            {
                currentItem.transform.localEulerAngles = new Vector3(-10f, 115f, -5f);
                cellContainer.SetActive(false);
                return;
            }
            if (currentItem.CompareTag("File"))
            {
                currentItem.transform.localEulerAngles = new Vector3(-180f, 90f, 0f);
                cellContainer.SetActive(false);
                return;
            }
            if (currentItem.gameObject.CompareTag("Flashlight"))
                {
                    FLButton.SetActive(true);
                    FL.isHaveFlashlight = true;
                    currentItem.transform.parent = flashLightPoint.transform;
                    currentItem.transform.localPosition = new Vector3(0, 0, 0);
                    currentItem.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                cellContainer.SetActive(false);
                return;
                }
         



        }
        cellContainer.SetActive(false);
    }

    public void ShowMessage(Sprite img, string textmessage)
    {
        pictureArea.SetActive(true);
        textArea.SetActive(true);
        pictureArea.GetComponent<Image>().sprite = img;
        textArea.GetComponent<TextMeshProUGUI>().text = textmessage;
        cellContainer.SetActive(false);
    }

    public void ChangeBulletAmt()
    {
        amt--;
    }

}

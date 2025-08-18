using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using static Joystick;
using UnityEngine.UI;

public class PanelInventyCell : MonoBehaviour, IPointerDownHandler
{
    public GameObject player;
    public Inventory inventory;
    public int takenItemID;
    public GameObject takenPrefab;
    public int itemIndex;
    [SerializeField] TextMeshProUGUI signPanel;
    [SerializeField] GameObject PicturePanel;

    void OnEnable()
    {
        player = GameObject.FindObjectOfType<Player>().gameObject;
        inventory = FindObjectOfType<Inventory>();

        for (int i = 0; i < inventory.cellContainer.transform.childCount; i++)
        {
            GameObject go = inventory.cellContainer.transform.GetChild(i).gameObject;
            if (inventory.cellContainer.transform.GetChild(i).gameObject.GetComponent<PanelInventyCell>().takenItemID == 7)
            {
                if (inventory.amt <= 0)
                {
                    PanelInventyCell pic = go.GetComponent<PanelInventyCell>();
                    pic.takenItemID = 0;
                    pic.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Image>().sprite = null;
                    go.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
                }
                else
                {
                    go.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = inventory.amt.ToString();
                }             
            }
        }

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (takenItemID != 0)
        {
            if (takenItemID != 7 && takenItemID !=13 && takenItemID !=14)
            {
                inventory.ShowTakenItem(takenItemID, takenPrefab);
            }
            else if (takenItemID == 13 || takenItemID ==14)
            {
                inventory.ShowMessage(takenPrefab.GetComponent<Item>().icon, takenPrefab.GetComponent<Item>().message);
            }
            else
            {
                signPanel.text = "";
                StartCoroutine(RemoveSign());
            }
        }
    }

    IEnumerator RemoveSign()
    {
        yield return new WaitForSeconds(0.5f);
        signPanel.text = "";
        StopCoroutine(RemoveSign());
    }

    void SetPicture()
    {
        PicturePanel.SetActive(true);
        PicturePanel.GetComponent<Image>().sprite = gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite;
    }

}

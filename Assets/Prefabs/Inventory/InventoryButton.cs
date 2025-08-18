using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryButton : MonoBehaviour,IPointerDownHandler
{
    public GameObject inventoryPanel;
    [SerializeField] GameObject pictureArea;
    [SerializeField] GameObject textArea;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(false);
        }
        else
        {
            inventoryPanel.SetActive(true);
        }
        if (pictureArea.activeSelf || textArea.activeSelf)
        {
            pictureArea.SetActive(false);
            textArea.SetActive(false);
        }

    }
}

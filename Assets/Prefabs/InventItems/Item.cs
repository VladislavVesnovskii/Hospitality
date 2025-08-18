using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "InventoryItem", menuName = "InventoryItems")]
public class Item : MonoBehaviour
{

    public string nameItem;
    [Multiline(5)]
    public string descriptionItem;
    public int id;
    [HideInInspector]
    public int countItem;
    public bool isStackable;
    public Sprite icon;
    public GameObject prefab;
    public bool isShown;
    public string message;

}

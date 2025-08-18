using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;


public class SaveSystem : MonoBehaviour
{
    [SerializeField] Transform itemWarehouse;
    [SerializeField] HealthComponent healthComponent;
    [SerializeField] Inventory itemNumbers;
    [SerializeField] Bell bell;



    public void OnEnable()
    {
        EventBus.OnSaveGame += SaveData;
        EventBus.OnLoadGame += LoadData;
        EventBus.OnResetGame += ResetData;
    }

    public void OnDisable()
    {
        EventBus.OnSaveGame -= SaveData;
        EventBus.OnLoadGame -= LoadData;
        EventBus.OnResetGame -= ResetData;
    }
    //[SerializeField] GameObject GO;
    public void SaveData()
    {
        //binary formatter saving
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/MySaveData.dat");
        PlayerData playerData = new PlayerData();
        playerData.health = healthComponent.health;
        int cc = itemNumbers.cellContainer.transform.childCount;
        playerData.itemNumbers = new int[cc];
        playerData.itemPositionX = new float[cc];
        playerData.itemPositionY = new float[cc];
        playerData.itemPositionZ = new float[cc];
        playerData.bulletAmount = itemNumbers.amt;
        playerData.bellAlarmOff = bell.alarmOff;

        for (int i = 0; i < itemNumbers.cellContainer.transform.childCount; i++)
        {
            if (itemNumbers.cellContainer.transform.GetChild(i).GetComponent<PanelInventyCell>().takenItemID != 0)
            {
                int tii = itemNumbers.cellContainer.transform.GetChild(i).GetComponent<PanelInventyCell>().takenItemID;
                playerData.itemNumbers[i] = tii;
                playerData.itemPositionX[i] = itemNumbers.prefabDictionary[tii].transform.position.x;
                playerData.itemPositionY[i] = itemNumbers.prefabDictionary[tii].transform.position.y;
                playerData.itemPositionZ[i] = itemNumbers.prefabDictionary[tii].transform.position.z;
            }


        }
        bf.Serialize(file, playerData);
        file.Close();
        Debug.Log("Game data saved!");


        //xml saving
        //var xml = new XmlSerializer(typeof(PlayerData));
        //var playerData = new PlayerData();
        //playerData.health = healthComponent.health;
        //playerData.itemNumbers = new int[itemNumbers.cellContainer.transform.childCount];
        //playerData.itemPositionX= new float[itemNumbers.cellContainer.transform.childCount];
        //playerData.itemPositionY= new float[itemNumbers.cellContainer.transform.childCount];
        //playerData.itemPositionZ= new float[itemNumbers.cellContainer.transform.childCount];
        //playerData.bulletAmount = itemNumbers.amt;
        
        //for (int i = 0; i < itemNumbers.cellContainer.transform.childCount; i++)
        //{
        //    if (itemNumbers.cellContainer.transform.GetChild(i).GetComponent<PanelInventyCell>().takenItemID !=0)
        //    {
        //        playerData.itemNumbers[i] = itemNumbers.cellContainer.transform.GetChild(i).GetComponent<PanelInventyCell>().takenItemID;
        //        playerData.itemPositionX[i] = itemNumbers.prefabDictionary[itemNumbers.cellContainer.transform.GetChild(i).GetComponent<PanelInventyCell>().takenItemID].transform.position.x;
        //        playerData.itemPositionY[i] = itemNumbers.prefabDictionary[itemNumbers.cellContainer.transform.GetChild(i).GetComponent<PanelInventyCell>().takenItemID].transform.position.y;
        //        playerData.itemPositionZ[i] = itemNumbers.prefabDictionary[itemNumbers.cellContainer.transform.GetChild(i).GetComponent<PanelInventyCell>().takenItemID].transform.position.z;
        //    }


        //}

        //    using (var stream = new FileStream("Test.xml", FileMode.Create, FileAccess.Write))
        //{
        //    xml.Serialize(stream, playerData);
        //}

    }

public void LoadData()
    {
        //binari formatter loading
        if (File.Exists(Application.persistentDataPath
    + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
              File.Open(Application.persistentDataPath
              + "/MySaveData.dat", FileMode.Open);
            PlayerData playerData = (PlayerData)bf.Deserialize(file);
            file.Close();
            healthComponent.health = playerData.health;
            itemNumbers.amt = playerData.bulletAmount;
            bell.alarmOff = playerData.bellAlarmOff;
            for (int i = 0; i < itemNumbers.cellContainer.transform.childCount; i++)
            {
                if (playerData.itemNumbers[i] != 0)
                {
                    PanelInventyCell pic = itemNumbers.cellContainer.transform.GetChild(i).GetComponent<PanelInventyCell>();
                    pic.takenItemID = playerData.itemNumbers[i];
                    pic.takenPrefab = itemNumbers.prefabDictionary[playerData.itemNumbers[i]];
                    pic.takenPrefab.layer = 7;
                    itemNumbers.cellContainer.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = itemNumbers.prefabDictionary[playerData.itemNumbers[i]].GetComponent<Item>().icon;
                    //pic.takenPrefab.transform.position = new Vector3(playerData.itemPositionX[i], playerData.itemPositionY[i], playerData.itemPositionZ[i]);
                    pic.takenPrefab.transform.position = itemWarehouse.position;
                }
            }
            Debug.Log("Game data loaded!");
        }
        else
            Debug.Log("There is no save data!");

        //xml loading
        //var xml = new XmlSerializer(typeof(PlayerData));
        //var playerData = new PlayerData();
        //using (var stream = new FileStream("Test.xml", FileMode.Open, FileAccess.Read))
        //{
        //    playerData = xml.Deserialize(stream) as PlayerData;
        //}
        //healthComponent.health = playerData.health;
        //itemNumbers.amt = playerData.bulletAmount;
        //for (int i = 0; i < itemNumbers.cellContainer.transform.childCount; i++)
        //{
        //    if (playerData.itemNumbers[i] != 0)
        //    {
        //        itemNumbers.cellContainer.transform.GetChild(i).GetComponent<PanelInventyCell>().takenItemID = playerData.itemNumbers[i];
        //        itemNumbers.cellContainer.transform.GetChild(i).GetComponent<PanelInventyCell>().takenPrefab = itemNumbers.prefabDictionary[playerData.itemNumbers[i]];
        //        itemNumbers.cellContainer.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = itemNumbers.prefabDictionary[playerData.itemNumbers[i]].GetComponent<Item>().icon;
        //        itemNumbers.cellContainer.transform.GetChild(i).GetComponent<PanelInventyCell>().takenPrefab.transform.position = new Vector3(playerData.itemPositionX[i], playerData.itemPositionY[i],playerData.itemPositionZ[i]);
                
        //    }
        //}
    }
    public static void ResetData()
    {
        if (File.Exists(Application.persistentDataPath
          + "/MySaveData.dat"))
        {
            File.Delete(Application.persistentDataPath
              + "/MySaveData.dat");
            Debug.Log("Data reset complete!");
        }
        else
            Debug.Log("No save data to delete.");
    }
}

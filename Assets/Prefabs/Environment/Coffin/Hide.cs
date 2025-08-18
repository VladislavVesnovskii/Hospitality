using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    [SerializeField] GameObject itemInformationPanel;
    [SerializeField] Transform playerTr;
    [SerializeField] float distanse;
    public bool hideIsShown;
    [SerializeField] GameObject coffinCam;
    [SerializeField] GameObject flashLightPanel;
    [SerializeField] Transform coffinTr;
    [SerializeField] Vector3 initialPosition;
    [SerializeField] GameObject itemCamera;

    void Update()
    {
        ShowPanel();
    }

    void ShowPanel()
    {
        if (Vector3.Distance(transform.position, playerTr.position) <= distanse)
        {
            itemInformationPanel.SetActive(true);
        }
        else
        {   
            itemInformationPanel.SetActive(false);
        }
    }

    public void GoInside()
    {
        if (!hideIsShown)
        {
            playerTr.GetComponent<CharacterController>().enabled = false;
            initialPosition = playerTr.position;
            playerTr.position = new Vector3(coffinTr.position.x, playerTr.position.y, coffinTr.position.z);
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y -0.8f, Camera.main.transform.position.z);
            itemCamera.transform.position = new Vector3(itemCamera.transform.position.x, itemCamera.transform.position.y - 0.8f, itemCamera.transform.position.z);
            playerTr.GetComponent<Player>().moveSpeed = 0f;
            playerTr.GetComponent<Player>().isCrouched = true;
            flashLightPanel.SetActive(false);
            playerTr.GetComponent<CharacterController>().enabled = true;
            hideIsShown = true;
            EventBus.OnHide?.Invoke(hideIsShown);

        }
        else
        {
            playerTr.GetComponent<CharacterController>().enabled = false;
            playerTr.position = initialPosition;
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + 0.8f, Camera.main.transform.position.z);
            itemCamera.transform.position = new Vector3(itemCamera.transform.position.x, itemCamera.transform.position.y + 0.8f, itemCamera.transform.position.z);
            playerTr.GetComponent<Player>().moveSpeed = 5f;
            playerTr.GetComponent<Player>().isCrouched = false;
            hideIsShown = false;
            playerTr.GetComponent<CharacterController>().enabled = true;
            EventBus.OnHide?.Invoke(hideIsShown);
        }
    }
}

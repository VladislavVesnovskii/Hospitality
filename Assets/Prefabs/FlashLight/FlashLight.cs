using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlashLight : MonoBehaviour, IPointerDownHandler
{
    public static bool isON;
    public bool isHaveFlashlight;
    [SerializeField] GameObject lightF;
    [SerializeField] GameObject lightImage;


    public void SwitchFlashlight()
    {
        if (isHaveFlashlight)
        {
            if (isON)
            {
                lightF.SetActive(true);
                lightImage.SetActive(true);
                isON = false;
                EventBus.chaseRange = 10f;
            }
            else
            {
                lightF.SetActive(false);
                lightImage.SetActive(false);
                isON = true;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SwitchFlashlight();
    }
}

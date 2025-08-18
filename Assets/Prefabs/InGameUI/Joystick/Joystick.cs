using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] RectTransform ThumbStickTrans;
    [SerializeField] RectTransform BackgroundTrans;
    [SerializeField] RectTransform CenterTrans;
    bool bWasDragging = false;

    public delegate void OnStickInputValueUpdated(Vector2 inputVal);
    public delegate void OnStickTaped();// For tapped the button

    public event OnStickInputValueUpdated onStickInputValueUpdated;
    public event OnStickTaped onStickTaped;//For tapped the button

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log($"Coordinate positions{eventData.position}");
        Vector2 touchPos = eventData.position;
        Vector2 centerPos = BackgroundTrans.position;

        Vector2 localOffcet = Vector2.ClampMagnitude(touchPos-centerPos, BackgroundTrans.sizeDelta.x/6);
        Vector2 inputVal = localOffcet / (BackgroundTrans.sizeDelta.x / 6);
        ThumbStickTrans.position = centerPos + localOffcet;

        onStickInputValueUpdated?.Invoke(inputVal);
        bWasDragging = true;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //BackgroundTrans.position = eventData.position;
        ThumbStickTrans.position = eventData.position;
        bWasDragging = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //BackgroundTrans.position = CenterTrans.position;
        ThumbStickTrans.position = BackgroundTrans.position;
        onStickInputValueUpdated?.Invoke(Vector2.zero);
        if (!bWasDragging)
        {
            onStickTaped?.Invoke();
        }
    }

}

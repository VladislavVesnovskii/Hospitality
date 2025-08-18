using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] Joystick aimStick;
    [SerializeField] float turnSpeed;
    [SerializeField] float upSpeed;
    //[SerializeField] GameObject pivot;
    Vector2 aimInput;
    [SerializeField] float camRotationX;
    void aimStickUpdated(Vector2 inputValue)
    {
        aimInput = inputValue;
    }
    public void OnEnable()
    {
        aimStick.onStickInputValueUpdated += aimStickUpdated;
    }
    public void OnDisable()
    {
        aimStick.onStickInputValueUpdated -= aimStickUpdated;
    }
    void Update()
    {
        LookAround();
    }

    void LookAround()
    {
        float mouseX = aimInput.x;
        camRotationX += mouseX;
        camRotationX = Mathf.Clamp(camRotationX, -120, 120);
        transform.localRotation = Quaternion.Euler( 0, camRotationX * upSpeed, 0);
    }
}

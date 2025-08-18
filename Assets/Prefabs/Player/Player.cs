using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float lowCamLevel;
    [SerializeField] float highCamLevel;
    [SerializeField] Joystick moveStick;
    [SerializeField] Joystick aimStick;
    [SerializeField] CharacterController characterController;
    public float moveSpeed;
    [SerializeField] float turnSpeed;
    [SerializeField] float upSpeed;
    [SerializeField] GameObject pivot;
    [SerializeField] GameObject questItemPoint;
    [SerializeField]
    Sprite[] sprites;
    [SerializeField] GameObject sitUpPanel;
    Vector2 moveInput;
    Vector2 aimInput;
    float camRotationY;
    public bool isCrouched;
    [SerializeField] Animator animator;
    [SerializeField] FootSteps footsteps;
    Camera mainCam;

    [Header("Inventory")]
    [SerializeField] Inventory inventory;
    //For landing
    Vector3 velocity;
    float gravity = -9.81f;

    void Start()
    {
        moveStick.onStickInputValueUpdated += moveStickUpdated;
        aimStick.onStickInputValueUpdated += aimStickUpdated;
        moveStick.onStickTaped += SitUp;
        aimStick.onStickTaped += TookItemAndShowDisplay;
        mainCam = Camera.main;
    }

    public void SitUp()
    {
        Vector3 objectPosition = Camera.main.transform.localPosition;
        Image img = sitUpPanel.GetComponent<Image>();
        if (!isCrouched)
        {
            characterController.enabled = false;
            Camera.main.transform.localPosition = new Vector3(objectPosition.x, objectPosition.y-0.5f, objectPosition.z);
            characterController.height /= 2;
            moveSpeed /= 2;
            img.sprite = sprites[1];
            isCrouched = true;
            characterController.enabled = true;
            if(!FlashLight.isON) EventBus.chaseRange = 3f;
        }
        else
        {
            characterController.enabled = false;
            Camera.main.transform.localPosition = new Vector3(objectPosition.x, objectPosition.y + 0.5f, objectPosition.z);
            characterController.height *= 2;
            moveSpeed *= 2;
            img.sprite = sprites[0];
            isCrouched = false;
            characterController.enabled = true;
            EventBus.chaseRange = 10f;
        }
    }

    public void TookItemAndShowDisplay()
    {
        
        inventory.AddItemToInventory();
        
    }
    void aimStickUpdated(Vector2 inputValue)
    {
        aimInput = inputValue;
    }
    void moveStickUpdated (Vector2 inputValue)
    {
        moveInput = inputValue;
    }
    public void CamUpRotation()
    {
        float mouseY = aimInput.y;
        camRotationY -= mouseY;
        camRotationY = Mathf.Clamp(camRotationY, lowCamLevel, highCamLevel);
        pivot.transform.localRotation = Quaternion.Euler(camRotationY*upSpeed, 0, 0);
    }
    
    void Update()
    {
        //for Landing
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        Vector3 forwardDir = mainCam.transform.right;
        Vector3 upDir = Vector3.Cross(forwardDir,Vector3.up);
        Vector3 moveDir = forwardDir*moveInput.x + upDir*moveInput.y;
        characterController.Move(moveDir * Time.deltaTime * moveSpeed);
        if (!isCrouched)
        {
            if (moveDir != Vector3.zero)
            {
                footsteps.StartWalking();
            }
            else
            {
                footsteps.StopWalking();
            }
        }
        
        gameObject.transform.Rotate(0, aimInput.x * Time.deltaTime * turnSpeed, 0);
        CamUpRotation();

    }

    
    public void ActivatePlayer()
    {
        this.enabled = true;
        animator.enabled = false;
    }

}

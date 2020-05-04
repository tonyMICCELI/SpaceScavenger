﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFerg : MonoBehaviour
{
    [Header("Rotation")]
    public RotationMode rotationMode = RotationMode.followMouse;
    public enum RotationMode { followMouse, controlledWithInputs };
    //bool lockCursor = false; //A utiliser si vous voulez cacher votre curseur 

    [Header("Speed")]
    public float walkSpeed = 2;
    public float sprintSpeed = 6;
    Vector2 lastInputDir;

    [Header("Smoothing")]
    public bool instantStop = true;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;

    [Header("Debug")]
    [SerializeField] float currentSpeed;

    Rigidbody2D playerRigidbody;
    Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();

        /*if (lockCursor) //A utiliser si vous voulez cacher votre curseur 
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }*/
    }

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;
        if (inputDir != Vector2.zero) lastInputDir = inputDir;

        bool running = Input.GetKey(KeyCode.LeftShift);

        //Rotation
        if (rotationMode == RotationMode.controlledWithInputs)
        {
            playerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            if (inputDir != Vector2.zero)
            {
                float targetRotation = Mathf.Atan2(-inputDir.x, inputDir.y) * Mathf.Rad2Deg;
                transform.eulerAngles = Vector3.forward * Mathf.SmoothDampAngle(transform.eulerAngles.z, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
            }
        }else
        {
            if (rotationMode == RotationMode.followMouse)
            {
                playerRigidbody.constraints = RigidbodyConstraints2D.None;
                Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Vous pouvez aussi faire reference à la caméra dans les attributs comme dans le code de base de Nazah mais blc
                Vector2 lookDir = MousePos - playerRigidbody.position;
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
                playerRigidbody.rotation = angle;
            }
        }

        //Position
        float targetSpeed = ((running) ? sprintSpeed : walkSpeed) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        playerRigidbody.velocity = currentSpeed * (instantStop ? inputDir : lastInputDir);
        currentSpeed = playerRigidbody.velocity.magnitude;

        //Animation
        //float animationSpeedPercent = ((running) ? currentSpeed / sprintSpeed : currentSpeed / walkSpeed * 0.5f) * inputDir.magnitude;
        //animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
    }

    private void OnValidate()
    {
        if (rotationMode == RotationMode.controlledWithInputs)
        {
            playerRigidbody = GetComponent<Rigidbody2D>();
            playerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            if (rotationMode == RotationMode.followMouse)
            {
                playerRigidbody = GetComponent<Rigidbody2D>();
                playerRigidbody.constraints = RigidbodyConstraints2D.None;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private float timer = 0.0f;
    public float timeAcceleration;
    public Camera cam;
    public Vector2 mousePos;
    public Rigidbody2D rb;
    Vector2 movement;
    public Vector2 MousePos;
    public float accelCoolDown;
    private bool enableAccel = true;


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        MousePos = cam.ScreenToWorldPoint(Input.mousePosition);

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = MousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        if (Input.GetButtonDown("Acceleration") && enableAccel == true)
        {
            acceleration();
        }
        timerAcceleration();

    }
    void acceleration()
    {
        moveSpeed += 10;
        timer = 0.0f;
        enableAccel = false;
    }
    void timerAcceleration()
    {
        timer += Time.deltaTime;
        if (timer > timeAcceleration)
        {
            moveSpeed = 5;
        }
        if(timer > accelCoolDown)
        {
            enableAccel = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Camera cam;
    public Vector2 mousePos;
    public Rigidbody2D rb;
    Vector2 movement;
    public Vector2 MousePos;
    public bool enableDash = true;
    public float timer = 0.0f;
    public float dashCoolDown = 5f;

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
        if (Input.GetKeyDown(KeyCode.Space) && enableDash == true)
        {
            dash();
        }
        timerDash();

    }
    void dash()
    {  
        rb.position = MousePos;
        timer = 0.0f;
        enableDash = false;
    }
    void timerDash()
    {
        timer += Time.deltaTime;
        if(timer > dashCoolDown)
        {
            enableDash = true;
        }
    }
}
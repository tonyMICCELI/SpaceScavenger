using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuFollow : MonoBehaviour
{
    /*private Vector3 mousePosition;
    
    private Vector2 dir;*/
    private Rigidbody2D rb;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        rb.transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);*/
        Vector2 heading = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        var distance = heading.magnitude;
        Vector2 direction = heading / distance;
        rb.velocity = direction * (distance < moveSpeed ? distance : moveSpeed);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class motherShipMoving : MonoBehaviour
{
    public Transform target;
    Rigidbody2D rb;
    public float moveSpeed;
    public string level;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        if (rb.transform.position.y == target.position.y)
        {
            SceneManager.LoadScene(level);
        }
    }
}

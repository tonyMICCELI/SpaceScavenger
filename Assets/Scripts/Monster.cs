using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform target;
    public Rigidbody2D rb;
    public int moveSpeed;
    float xrnd;
    float yrnd;
    public float xlim, ylim;
    public float patrolReload;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(patrolRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        moving();
    }

    public void moving()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D playerCollider)
    {
        if (playerCollider.gameObject.CompareTag("Player"))
        {
            rb.velocity = new Vector2(0.0f, 0.0f);
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 
        }
    }

    public void patrol()
    {
        xrnd = Random.Range(-xlim, xlim);
        yrnd = Random.Range(-ylim, ylim);
        rb.velocity = new Vector2(xrnd*moveSpeed/2, yrnd*moveSpeed/2);
    }
    
    IEnumerator patrolRoutine()
    {
        while (target != GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>())
        {
            patrol();
            yield return new WaitForSeconds(patrolReload);
        }
    }
}

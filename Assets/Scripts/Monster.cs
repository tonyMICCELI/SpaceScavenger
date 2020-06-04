using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    protected Transform target;
    public Rigidbody2D rb;
    public int moveSpeed;
    float xrnd;
    float yrnd;
    public float xlim, ylim;
    public float patrolReload;
    public Transform firePoint;
    public GameObject shootPrefab;
    public float bulletForce;
    public DialogueManager dialogueManager;



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
        if (GameObject.FindWithTag("Monster") != null && target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D playerCollider)
    {
        if (playerCollider.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Monster");
            rb.velocity = new Vector2(0.0f, 0.0f);
            if(dialogueManager.get_active()==false)
            {
                target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
                shoot();
            }
        } 
    }
    public Transform get_target()
    {
        return target;
    }
    public virtual void shoot() 
    {
        if(firePoint != null)
        {
            GameObject shoot = Instantiate(shootPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rbShoot = shoot.GetComponent<Rigidbody2D>();
            Vector2 rbForce = get_target().position - firePoint.position;
            rbShoot.AddForce(rbForce * bulletForce, ForceMode2D.Impulse);
        }
    }

    public void patrol()
    {
        if(dialogueManager.get_active()==false)
        {
            xrnd = Random.Range(-xlim, xlim);
            yrnd = Random.Range(-ylim, ylim);
            rb.velocity = new Vector2(xrnd * moveSpeed / 2, yrnd * moveSpeed / 2);
        }
    }
    
    public virtual IEnumerator patrolRoutine()
    {
        while (target != GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>())
        {
            patrol();
            yield return new WaitForSeconds(patrolReload);
        }
    }
    public Rigidbody2D get_rb()
    {
        return rb;    
    }
    
}

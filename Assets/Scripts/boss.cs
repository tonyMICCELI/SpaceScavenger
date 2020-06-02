using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : Monster
{
    public Transform firePoint2;
    public Transform firePoint3;

    void Start()
    {
        StartCoroutine(patrolRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D playerCollider)
    {
        if (playerCollider.gameObject.CompareTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            shoot(firePoint);
            shoot(firePoint2);
            shoot(firePoint3);
        }
    }
    public void shoot(Transform firePoint) 
    {
        GameObject shoot = Instantiate(shootPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rbShoot = shoot.GetComponent<Rigidbody2D>();
        Vector2 rbForce = get_target().position - firePoint.position;
        rbShoot.AddForce(rbForce * bulletForce, ForceMode2D.Impulse);
    }
    public override IEnumerator patrolRoutine()
    {
        while(true)
        {
            patrol();
            yield return new WaitForSeconds(patrolReload);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint1;
    public GameObject laserPrefab;
    public GameObject laserPrefab1;

    public float bulletForce;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }
   

    void shoot()
    {
        GameObject laser = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        GameObject laser1 = Instantiate(laserPrefab1, firePoint1.position, firePoint1.rotation);

        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
        Rigidbody2D rb1 = laser1.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        rb1.AddForce(firePoint1.up * bulletForce, ForceMode2D.Impulse);
    }
    
}

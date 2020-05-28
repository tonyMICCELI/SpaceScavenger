using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint1;
    public GameObject laserPrefab;
    public GameObject laserPrefab1;

    public float bulletForce;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) //si le bouton associé a Fire1 est appuyé
        {
            FindObjectOfType<AudioManager>().Play("Laser");
            shoot();
        }
    }
   

    void shoot()
    {
        GameObject laser = Instantiate(laserPrefab, firePoint.position, firePoint.rotation); // on créé un laser, son apparence est laserPrefab, il est créé a la position du firePoint, et à l'angle du firePoint
        GameObject laser1 = Instantiate(laserPrefab1, firePoint1.position, firePoint1.rotation);

        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>(); //on prend leur Rigidbody pour gérer les colisions
        Rigidbody2D rb1 = laser1.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); // on leur donne une vitesse
        rb1.AddForce(firePoint1.up * bulletForce, ForceMode2D.Impulse);
    }
    
}

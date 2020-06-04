using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint1;
    public GameObject laserPrefab;
    private float timer = 0.0f;
    public float timeShoot;
    private bool enable =true;

    public float bulletForce;

    public PauseMenu pauseMenu;
    public DialogueManager dialogueManager;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")&& pauseMenu.getBool() ==false && enable == true && dialogueManager.get_active() == false) //si le bouton associé a Fire1 est appuyé
        {
            shoot();
        }
        timerShoot();
    }
   

    void shoot()
    {
        FindObjectOfType<AudioManager>().Play("Laser");
        GameObject laser = Instantiate(laserPrefab, firePoint.position, firePoint.rotation); // on créé un laser, son apparence est laserPrefab, il est créé a la position du firePoint, et à l'angle du firePoint
        GameObject laser1 = Instantiate(laserPrefab, firePoint1.position, firePoint1.rotation);

        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>(); //on prend leur Rigidbody pour gérer les colisions
        Rigidbody2D rb1 = laser1.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); // on leur donne une vitesse
        rb1.AddForce(firePoint1.up * bulletForce, ForceMode2D.Impulse);
        timer = 0.0f;
        enable = false;
    }
    void timerShoot() //gère le temps de la compétence et le cool down
    {
        timer += Time.deltaTime; //le timer compte le temps passé 
        if (timer > timeShoot)
        {
            enable = true;
        }
    }

}

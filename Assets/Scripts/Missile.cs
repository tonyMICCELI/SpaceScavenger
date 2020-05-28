using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Transform missileLauncher;
    public Transform missileLauncher1;
    public GameObject missilePrefab;
    public GameObject missilePrefab1;


    public float missileSpeed;
    void Update()
    {
        if (Input.GetButtonDown("Missile"))//si le bouton associé a Missile est appuyé
        {
            FindObjectOfType<AudioManager>().Play("Rocket");
            missile();
        }
    }
    void missile()
    {
        GameObject missile = Instantiate(missilePrefab, missileLauncher.position, missileLauncher.rotation);// on créé un missile, son apparence est missilePrefab, il est créé a la position du missileLauncher, et à l'angle du missileLauncher
        GameObject missile1 = Instantiate(missilePrefab1, missileLauncher1.position, missileLauncher1.rotation);

        Rigidbody2D rb = missile.GetComponent<Rigidbody2D>(); //on en fait des Rigidbody pour gérer les colisions
        Rigidbody2D rb1 = missile1.GetComponent<Rigidbody2D>();

        rb.AddForce(missileLauncher.up * missileSpeed, ForceMode2D.Impulse); // on leur donne une vitesse
        rb1.AddForce(missileLauncher1.up * missileSpeed, ForceMode2D.Impulse);
    }
}

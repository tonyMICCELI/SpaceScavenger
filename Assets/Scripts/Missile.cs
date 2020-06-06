using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public static Missile instance;
    public Transform missileLauncher;
    public Transform missileLauncher1;
    public GameObject missilePrefab;
    public GameObject missilePrefab1;
    private bool isActive = true;
    private float timer = 0.0f;
    public float timeShoot;
    private bool enable = true;

    public float missileSpeed;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Update()
    {
        if (Input.GetButtonDown("Missile") && isActive == true && enable == true)//si le bouton associé a Missile est appuyé
        {
            missile();
        }
        timerShoot();
    }
    void missile()
    {
        FindObjectOfType<AudioManager>().Play("Rocket");
        GameObject missile = Instantiate(missilePrefab, missileLauncher.position, missileLauncher.rotation);// on créé un missile, son apparence est missilePrefab, il est créé a la position du missileLauncher, et à l'angle du missileLauncher
        GameObject missile1 = Instantiate(missilePrefab1, missileLauncher1.position, missileLauncher1.rotation);
        Physics2D.IgnoreCollision(missile.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(missile1.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Rigidbody2D rb = missile.GetComponent<Rigidbody2D>(); //on en fait des Rigidbody pour gérer les colisions
        Rigidbody2D rb1 = missile1.GetComponent<Rigidbody2D>();

        rb.AddForce(missileLauncher.up * missileSpeed, ForceMode2D.Impulse); // on leur donne une vitesse
        rb1.AddForce(missileLauncher1.up * missileSpeed, ForceMode2D.Impulse);
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

    public void MakeTrueRocket()
    {
        isActive = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoss : MonoBehaviour
{
    public static DamageBoss instance;
    public GameObject impact;
    public float life;
    public float maxLife;
    public HealthBar healthBar;
    public bool isAlive = true;


    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        life = maxLife;
        healthBar.setMaxHealth(maxLife);
    }
    void Update()
    {
        if (life < 0)
        {
            isAlive = false;
            GameObject effect = Instantiate(impact, transform.position, Quaternion.identity);//on instancie l'annimation à l'endroit de la colision
            Destroy(effect, 1f);// on détruit l'annimation après 1 seconde
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            life -= 1f;
            healthBar.setHealth(life);
        }
        if(collision.gameObject.CompareTag("Missile"))
        {
            life -= 5f;
            healthBar.setHealth(life);
        }
    }

    public bool GetBool()
    {
        return isAlive;
    }
}

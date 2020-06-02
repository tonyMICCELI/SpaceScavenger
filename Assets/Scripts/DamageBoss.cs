using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoss : MonoBehaviour
{
    public GameObject impact;
    public float life;
    public float maxLife;

    public HealthBar healthBar;

    public string level;

    private void Start()
    {
        life = maxLife;
        healthBar.setMaxHealth(maxLife);
    }
    void Update()
    {
        if (life < 0)
        {
            GameObject effect = Instantiate(impact, transform.position, Quaternion.identity);//on instancie l'annimation à l'endroit de la colision
            Destroy(effect, 1f);// on détruit l'annimation après 1 seconde
            wait();
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
            life -= 2f;
            healthBar.setHealth(life);
        }
    }
    public virtual IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMonster : MonoBehaviour
{
    public Collider2D detecMonster;
    public Collider2D laser;
    public Collider2D missile;

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreCollision(detecMonster, laser);
        Physics2D.IgnoreCollision(detecMonster, missile);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Destroy(gameObject);
        }
    }
}

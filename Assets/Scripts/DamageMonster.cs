﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMonster : MonoBehaviour
{
    public Collider2D detecMonster;
    public Collider2D laser;
    public Collider2D missile;
    public GameObject item;

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
            Vector3 itemPos = gameObject.transform.position;
            Destroy(gameObject);
            int nbItems = Random.Range(1, 4);
            for (int i = 0; i < nbItems; i++)
            {
                float x = Random.Range(-10, 10)/10f;
                float y = Random.Range(-10, 10) / 10f;
                GameObject a = Instantiate(item, itemPos + new Vector3(x, y, 1), gameObject.transform.rotation);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterShoot : MonoBehaviour
{
    public GameObject impact; //annimation d'impact

    private void Update()
    {
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Shield"))
        {
            GameObject effect = Instantiate(impact, transform.position, Quaternion.identity);//on instancie l'annimation à l'endroit de la colision
            Destroy(effect, 1f);// on détruit l'annimation après 1 seconde
            Destroy(gameObject);//on détruit le tir du monstre
        }

    }
}


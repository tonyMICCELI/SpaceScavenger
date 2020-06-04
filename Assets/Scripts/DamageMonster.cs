using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMonster : MonoBehaviour
{
    public GameObject item;
    public GameObject impact;

   
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon") || collision.gameObject.CompareTag("Shield"))
        {
            Vector3 itemPos = gameObject.transform.position;
            GameObject effect = Instantiate(impact, transform.position, Quaternion.identity);//on instancie l'annimation à l'endroit de la colision
            Destroy(effect, 1f);// on détruit l'annimation après 1 seconde
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

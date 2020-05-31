using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitEffect_laser : MonoBehaviour
{
    public GameObject impact; //annimation d'impact
    public GameObject shield;
    

    private void Update()
    {
        Physics2D.IgnoreCollision(shield.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        //Destroy(gameObject, 5f);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else
        {
            GameObject effect = Instantiate(impact, transform.position, Quaternion.identity);//on instancie l'annimation à l'endroit de la colision
            Destroy(effect, 1f);// on détruit l'annimation après 1 seconde
            Destroy(gameObject);//on détruit le missile
            
        }
        
    }
}

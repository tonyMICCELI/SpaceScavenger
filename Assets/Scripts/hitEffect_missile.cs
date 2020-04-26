using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitEffect_missile : MonoBehaviour
{
    public GameObject impact; //annimation d'impact
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(impact, transform.position, Quaternion.identity);//on instancie l'annimation à l'endroit de la colision
        Destroy(effect, 1f);// on détruit l'annimation après 1 seconde
        Destroy(gameObject);//on détruit le missile
    }
}

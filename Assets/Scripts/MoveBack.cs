using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    public bool cloose = false;
    public GameObject wave;
    private void OnTriggerEnter2D(Collider2D playerCollider)
    {
        if (playerCollider.gameObject.CompareTag("Player"))
        {
            cloose = true;
            GameObject effect = Instantiate(wave, transform.position, Quaternion.identity);//on instancie l'annimation à l'endroit de la colision
            Destroy(effect, 0.1f);// on détruit l'annimation après 1 seconde
        }
        else
        {
            cloose = false;
        }
    }
    public bool get_cloose()
    {
        return cloose;
    }
}

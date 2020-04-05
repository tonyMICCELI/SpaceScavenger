using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject impact;
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(impact, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
        Destroy(gameObject);
    }
}

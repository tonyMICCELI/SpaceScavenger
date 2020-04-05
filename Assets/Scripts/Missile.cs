using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Transform missileLauncher;
    public Transform missileLauncher1;
    public GameObject missilePrefab;
    public GameObject missilePrefab1;

    public float missileSpeed;
    void Update()
    {
        if (Input.GetButtonDown("Missile"))
        {
            missile();
        }
    }
    void missile()
    {
        GameObject missile = Instantiate(missilePrefab, missileLauncher.position, missileLauncher.rotation);
        GameObject missile1 = Instantiate(missilePrefab1, missileLauncher1.position, missileLauncher1.rotation);

        Rigidbody2D rb = missile.GetComponent<Rigidbody2D>();
        Rigidbody2D rb1 = missile1.GetComponent<Rigidbody2D>();

        rb.AddForce(missileLauncher.up * missileSpeed, ForceMode2D.Impulse);
        rb1.AddForce(missileLauncher1.up * missileSpeed, ForceMode2D.Impulse);
    }
}

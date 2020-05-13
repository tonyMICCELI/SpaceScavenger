using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPneu : Monster
{
    public Transform firePoint;
    public GameObject shootPrefab;
    public float bulletForce;
    public GameObject player; 
    private Vector3 targetPos;
    private GameObject shoots;

    // Update is called once per frame
    void Update()
    {
        shoots.transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime / 10f);
    }
    public override void shoot()
    {
        shoots = Instantiate(shootPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = shoots.GetComponent<Rigidbody2D>();
        targetPos = player.transform.position;
    }
}

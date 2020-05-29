using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject shieldPrefab;
    public GameObject target;
    private Vector3 targetPosition;
    private bool enable = true;
    private bool unlock = true;
    private float timer= 0.0f;
    public float timeShield;
    public float shieldCoolDown;
    private GameObject shield;
    


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Shield") && enable == true && unlock == true) // Si le bouton correspondant à l'acceleration est apuyé et que le cool down de la compétecnce est fini
        {
            activate();
        }
        timer1();
        shield.transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime/10f);
        
    }
    void activate()
    {
        targetPosition = target.transform.position;
        shield = Instantiate(shieldPrefab, targetPosition, target.transform.rotation);
        enable = false;
        timer = 0.0f;
    }
    void timer1() //gère le temps de la compétence et le cool down
    {
        timer += Time.deltaTime; //le timer compte le temps passé 
        if (timer > shieldCoolDown)
        {
            enable = true; //on permet de réutiliser la compétence
        }
    }
    public float getTime()
    {
        return timeShield;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Border"))
        {
            Destroy(collision);
        }
    }
}

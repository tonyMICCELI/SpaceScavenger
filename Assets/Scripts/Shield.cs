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
    private void Update()
    {
        if (GameObject.FindWithTag("Shield") != null)
        {
            Physics2D.IgnoreCollision(shield.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        
    }
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Shield") && enable == true && unlock == true) // Si le bouton correspondant au bouclier est apuyé et que le cool down de la compétecnce est fini
        {
            activate();
        }
        timer1();
        if(GameObject.FindWithTag("Shield") != null)
        {
            shield.transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime / 10f);
        }    
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
}

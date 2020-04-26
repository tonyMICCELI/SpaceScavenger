using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject shieldPrefab;
    public GameObject target;
    private Vector3 targetPosition;
    private bool enable = true;
    private float timer = 0.0f;
    public float timeShield;
    public float shieldCoolDown;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Shield") && enable == true) // Si le bouton correspondant à l'acceleration est apuyé et que le cool down de la compétecnce est fini
        {
            activate();
        }
        
    }
    void activate()
    {
        targetPosition = target.transform.position;
        GameObject shield = Instantiate(shieldPrefab, targetPosition,target.transform.rotation);
        shield.transform.position = Vector3.Lerp(transform.position, targetPosition, 1500 * Time.deltaTime);
    }
    void timerAcceleration() //gère le temps de la compétence et le cool down
    {
        timer += Time.deltaTime; //le timer compte le temps passé 
        if (timer > timeShield)
        {
            //Destroy(shield);
        }
        if (timer > shieldCoolDown)
        {
            enable = true; //on permet de réutiliser la compétence
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public float life;
    public float MonsterDamage;
   

    // Update is called once per frame
    void Update()
    {
        if(life<0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            life -= MonsterDamage * Time.deltaTime;
        }
    }
}

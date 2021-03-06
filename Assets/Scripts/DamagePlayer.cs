﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamagePlayer : MonoBehaviour
{
    public static DamagePlayer instance;
    public float life;
    public float maxLife;
    public float MonsterDamage;
    private bool lifeUpgrade = false;

    public HealthBar healthBar;
    public string level;


    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        life = maxLife;
        healthBar.setMaxHealth(maxLife);
    }
    // Update is called once per frame
    void Update()
    {
        if(life<0)
        {
            FindObjectOfType<AudioManager>().Play("Over2");
            FindObjectOfType<AudioManager>().Play("Over");
            ifDeathResetAll();
            SceneManager.LoadScene(level);

        }
        if (lifeUpgrade == true)
        {
            maxLife = maxLife * 2;
            life = maxLife;
            healthBar.setMaxHealth(maxLife);
            lifeUpgrade = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            life -= (MonsterDamage * Time.deltaTime)/4f;
            healthBar.setHealth(life);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MonsterShoot"))
        {
            life -= 1f;
            healthBar.setHealth(life);
        }
    }
    public void makeTrueLife()
    {
        lifeUpgrade = true;
    }
    public void ifDeathResetAll()
    {
        PlayerController.instance.ifDeathResetSkills();
        ScoreManager.instance.ifDeathResetSettings();
        Shield.instance.ifDeathResetShield();
    }
}

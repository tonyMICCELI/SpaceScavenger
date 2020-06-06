using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseOneSkill : MonoBehaviour
{
    public GameObject canvaSkills;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Dash()
    {
        FindObjectOfType<AudioManager>().Play("Skill");
        PlayerController.instance.makeTrueDash();
        Destroy(canvaSkills);
    }

    public void Accel()
    {
        FindObjectOfType<AudioManager>().Play("Skill");
        PlayerController.instance.makeTrueAccel();
        Destroy(canvaSkills);
    }

    public void Bouclier()
    {
        FindObjectOfType<AudioManager>().Play("Skill");
        Shield.instance.makeTrueShield();
        Destroy(canvaSkills);
    }

    public void Life()
    {
        FindObjectOfType<AudioManager>().Play("Skill");
        DamagePlayer.instance.makeTrueLife();
        Destroy(canvaSkills);
    }

    public void Rocket()
    {
        FindObjectOfType<AudioManager>().Play("Skill");
        Missile.instance.MakeTrueRocket();
        Destroy(canvaSkills);
    }
}

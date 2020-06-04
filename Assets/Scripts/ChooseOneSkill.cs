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
        PlayerController.instance.makeTrueDash();
        Destroy(canvaSkills);
    }

    public void Accel()
    {
        PlayerController.instance.makeTrueAccel();
        Destroy(canvaSkills);
    }

    public void Bouclier()
    {
        Shield.instance.makeTrueShield();
        Destroy(canvaSkills);
    }

    public void Life()
    {
        DamagePlayer.instance.makeTrueLife();
        Destroy(canvaSkills);
    }

    public void Rocket()
    {
        Missile.instance.MakeTrueRocket();
        Destroy(canvaSkills);
    }
}

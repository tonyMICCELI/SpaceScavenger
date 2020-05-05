using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineLight : MonoBehaviour
{
    private GameObject runningLight;
    public GameObject engineLight;
    public Animator enginePlayer;
    public Transform enginePos;
    public bool enable = true;
    void FixedUpdate()
    {
        if ((enginePlayer.GetFloat("SpeedX")>0.01f||enginePlayer.GetFloat("SpeedY")>0.01f)&& enable ==true) // Si le bouton correspondant à l'acceleration est apuyé et que le cool down de la compétecnce est fini
        {
            activate();
        }
        else
        {
            enable = true;
            Destroy(runningLight);
        }
        
        runningLight.transform.position = Vector3.Lerp(enginePos.position, enginePos.position, Time.deltaTime / 10);

    }
    void activate()
    {
        runningLight = Instantiate(engineLight, enginePos.position, enginePos.rotation);
        enable = false;
    }
}

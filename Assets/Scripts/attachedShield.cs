using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attachedShield : MonoBehaviour
{

    public float timeShield;
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,timeShield );
    }
}

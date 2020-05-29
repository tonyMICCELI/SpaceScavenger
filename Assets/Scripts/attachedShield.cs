using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attachedShield : MonoBehaviour
{
    public Shield shield;
    private float timeShield;
    private void Start()
    {
        timeShield = shield.getTime();
    }
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,timeShield);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBossAlive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DamageBoss.instance.SetAlive();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

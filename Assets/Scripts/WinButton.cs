﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinButton : MonoBehaviour
{
    public string level;
    // Start is called before the first frame update
    public void BackMenu()
    {
        SceneManager.LoadScene(level);
    }

    
}
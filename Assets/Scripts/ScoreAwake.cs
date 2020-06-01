using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAwake : MonoBehaviour
{
    public static ScoreAwake instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        if (instance == null) //there is no ScoreManager in the scene
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

    }
}

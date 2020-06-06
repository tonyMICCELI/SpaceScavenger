using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAwake : MonoBehaviour
{
    public static TextAwake instance;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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

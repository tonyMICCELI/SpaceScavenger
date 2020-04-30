using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{

    public GameObject objectsSpawned;

    float xrnd;
    float yrnd;
    public int nbrObjects;
    public float xlim, ylim;

    // Start is called before the first frame update
    void Start()
    {
        randomInstances();
    }

    void randomInstances()
    {
        for (int i = 0; i < nbrObjects; i++)
        {
            xrnd = Random.Range(-xlim, xlim);
            yrnd = Random.Range(-ylim, ylim);
            Instantiate(objectsSpawned, new Vector3(xrnd, yrnd, 1f), Quaternion.identity);
        }
        
    }
}

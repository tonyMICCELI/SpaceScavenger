using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHome : MonoBehaviour
{
    public static CheckHome instance;
    public bool isHome = false;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void OnTriggerEnter2D(Collider2D objCollider)
    {
        if (objCollider.gameObject.CompareTag("Player"))
        {
            isHome = true;
        }
    }

    private void OnTriggerExit2D(Collider2D objCollider)
    {
        if (objCollider.gameObject.CompareTag("Player"))
        {
            isHome = false;
        }
    }

    public bool GetBool()
    {
        return isHome;
    }
}

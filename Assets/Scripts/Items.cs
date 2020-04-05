using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D playerCollider)
    {
        if (playerCollider.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Metal"))
        {
            ScoreManager.instance.ChangeScoreMetal();
        }

        if (playerCollider.gameObject.CompareTag("Player") && this.gameObject.CompareTag("testObject"))
        {
            ScoreManager.instance.ChangeScoreTestObject();
        }
    }
}

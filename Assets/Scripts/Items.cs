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

        if (playerCollider.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Wheel"))
        {
            ScoreManager.instance.ChangeScoreWheel();
        }

        if (playerCollider.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Panel"))
        {
            ScoreManager.instance.ChangeScorePanel();
        }

        if (playerCollider.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Gas"))
        {
            ScoreManager.instance.ChangeScoreGas();
        }

        if (playerCollider.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Plastic"))
        {
            ScoreManager.instance.ChangeScorePlastic();
        }

        if (playerCollider.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Satellite"))
        {
            ScoreManager.instance.ChangeScoreSatellite();
        }
    }
}

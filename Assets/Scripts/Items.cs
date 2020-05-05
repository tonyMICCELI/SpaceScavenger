using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class Items : MonoBehaviour
{
    private int speedRotate = 90;
    public GameObject glolight;


    private void Start()
    {
    }
    void OnMouseOver()
    {
        transform.Rotate(Vector3.forward * -speedRotate * Time.deltaTime);
        glolight.transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);
    }

    private void OnMouseEnter()
    {
        glolight.transform.position = transform.position;

    }
    private void OnMouseExit()
    {
        transform.eulerAngles = Vector3.forward * 0;
        glolight.transform.position = new Vector3(200.0f, 200.0f, 0);
    }

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

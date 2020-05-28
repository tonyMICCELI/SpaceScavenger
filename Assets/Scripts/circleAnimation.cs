using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleAnimation : MonoBehaviour
{
    [SerializeField]
    Transform rotationCenter;

    [SerializeField]
    float rotationRadius = 2f;
    [SerializeField]
    float angularSpeed = 2f;
    float posX = 0f;
    float posY = 0f;
    float angle = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
        transform.position = new Vector2(posX, posY);
        angle += Time.deltaTime * angularSpeed;


        if (angle >= 360f)
            angle = 0f;
    }
}

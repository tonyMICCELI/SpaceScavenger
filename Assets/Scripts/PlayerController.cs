using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float moveSpeed;
    private float timer = 0.0f;
    public float timeAcceleration;
    public Camera cam;
    public Rigidbody2D rb;
    private Vector2 movement;
    public Vector2 MousePos;
    public float accelCoolDown;
    private bool enableAccel = true;
    public bool unlockAccel = false;
    public bool enableDash = true;
    private bool unlockDash = false;
    public float dashCoolDown = 5f;
    public Animator engine;
    public MoveBack moveBack;
    public boss boss;



    void Start()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        
    }

    // Update is called once per frame
    void Update()
    {   
        movement.x = Input.GetAxisRaw("Horizontal");  //mouvements du vaisseau selon l'axe x   
        movement.y = Input.GetAxisRaw("Vertical");    //mouvemnts du vaisseau selon l'axe y
        MousePos = cam.ScreenToWorldPoint(Input.mousePosition); //récupère les coordonnées de la souris sur l'écran et les convertie en coordonnées unity 
        engine.SetFloat("SpeedX", Mathf.Abs(movement.x*moveSpeed));
        engine.SetFloat("SpeedY", Mathf.Abs(movement.y*moveSpeed));
    }

    void FixedUpdate()
    {
        if(moveBack)
        {
            if (moveBack.get_cloose() == true)
            {
                Vector2 bossPos = boss.get_rb().position;
                rb.MovePosition(rb.position - (bossPos - rb.position) * 10 * moveSpeed * Time.fixedDeltaTime);
            }
            else
            {
                rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); //Met à jour la position du vaisseau 
            }
        }
        else
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); //Met à jour la position du vaisseau 
        }
        Vector2 lookDir = MousePos - rb.position; //Vecteur entre le vaisseau et le pointeur de souris, soit la direction ou doit poiter le nez du vaisseau
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f; //angle angle entre l'axe horizontal et lookdir, correspondant à la direction dans laquelle doit etre le vaisseau
        rb.rotation = angle; //rotation du vaisseau = angle entre l'axe horizontal et lookdir
        if (Input.GetButtonDown("Acceleration") && enableAccel == true && unlockAccel == true) // Si le bouton correspondant à l'acceleration est apuyé et que le cool down de la compétecnce est fini
        {
            acceleration();
        }
        timerAcceleration();
        if (Input.GetButtonDown("Dash") && enableDash == true && unlockDash == true)
        {
            dash();
        }
        timerDash();
    }


    private void OnTriggerEnter2D(Collider2D objCollider)
    {
        if (objCollider.gameObject.CompareTag("Metal") || objCollider.gameObject.CompareTag("Cigaret") || objCollider.gameObject.CompareTag("Wheel")
            || objCollider.gameObject.CompareTag("Panel") || objCollider.gameObject.CompareTag("Plastic") 
            || objCollider.gameObject.CompareTag("Gas") || objCollider.gameObject.CompareTag("Satellite"))
        {
            FindObjectOfType<AudioManager>().Play("Collect");
            Destroy(objCollider.gameObject);
        }
    }




     



    void acceleration() //fonction permettant l'acceleration du vaisseau
    {
        moveSpeed += 10; // la vitesse augmente de 10
        timer = 0.0f; //timer permettant de limiter le temps de la compétence
        enableAccel = false; //interdit la réutilisation de la compétence avant un moment
    }
    void timerAcceleration() //gère le temps de la compétence et le cool down
    {
        timer += Time.deltaTime; //le timer compte le temps passé 
        if (timer > timeAcceleration) 
        {
            moveSpeed = 5; //on remet la vitesse à sa valeur de base
        }
        if(timer > accelCoolDown)
        {
            enableAccel = true; //on permet de réutiliser la compétence
        }
    }
    void dash()
    {
        rb.position = MousePos;
        timer = 0.0f;
        enableDash = false;
    }
    void timerDash()
    {
        timer += Time.deltaTime;
        if (timer > dashCoolDown)
        {
            enableDash = true;
        }
    }

    public void makeTrueDash()
    {
        if (!unlockDash)
        {
            unlockDash = true;
        }
    }

    public void makeTrueAccel()
    {
        if (!unlockAccel)
        {
            unlockAccel = true;
        }
    }

    public void ifDeathResetSkills()
    {
        unlockAccel = false;
        unlockDash = false;
    }

    public bool getAccelState()
    {
        return unlockAccel;
    }

    public bool getDashState()
    {
        return unlockDash;
    }
}

    


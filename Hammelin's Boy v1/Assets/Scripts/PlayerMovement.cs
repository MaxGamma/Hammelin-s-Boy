using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeedPlayer;
    public float moveSpeedRat;
    public float jumpForcePlayer;
    public float jumpForceRat;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    float value;
    float value2;
    bool value3;

    private GameObject enemies;
    private GameObject platforms;
    private GameObject spikes;
    private GameObject pendulum;

    private Rigidbody2D theRB;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;

    public bool touchingLeftWall;
    public bool touchingRightWall;

    public Animator boyAnim;
    public Animator ratAnim;
    public Animator gameOverAnim;

    public bool dead = false;

    private bool paused = false;
    private RigidbodyConstraints2D originalConstraints;

    public GameObject pausemenu;

    Stopwatch timer;


    // Use this for initialization
    void Start ()
    {
        theRB = GetComponent<Rigidbody2D>();

        boyAnim = boyAnim.GetComponent<Animator>();
        ratAnim = ratAnim.GetComponent<Animator>();
        gameOverAnim = gameOverAnim.GetComponent<Animator>();

        touchingLeftWall = false;
        touchingRightWall = false;

        enemies = GameObject.Find("Enemies");
        platforms = GameObject.Find("Platforms");
        spikes = GameObject.Find("Spikes");
        pendulum = GameObject.Find("Pendulum");
    }
	
	// Update is called once per frame
	void Update ()
    {
            value = Input.GetAxis("Horizontal");
            value2 = Input.GetAxis("Jump");
            value3 = Input.GetKeyDown("joystick button 7");


        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

            if ((Input.GetKey(left) || value == -1) && touchingLeftWall == false)
            {
                if (gameObject.tag == "Player")
                {
                    boyAnim.SetBool("boyMovement", true);
                    theRB.velocity = new Vector2(-moveSpeedPlayer, theRB.velocity.y);
                }
                if (gameObject.tag == "Rat")
                {
                    ratAnim.SetBool("ratMovement", true);
                    theRB.velocity = new Vector2(-moveSpeedRat, theRB.velocity.y);
                }

                touchingRightWall = false;
            }
            else if ((Input.GetKey(right) || value == 1) && touchingRightWall == false)
            {
                if (gameObject.tag == "Player")
                {
                    boyAnim.SetBool("boyMovement", true);
                    theRB.velocity = new Vector2(moveSpeedPlayer, theRB.velocity.y);
                    
                }
                if (gameObject.tag == "Rat")
                {
                    ratAnim.SetBool("ratMovement", true);
                    theRB.velocity = new Vector2(moveSpeedRat, theRB.velocity.y);
                }

                touchingRightWall = false;
            }
            else
            {
                boyAnim.SetBool("boyMovement", false);
                ratAnim.SetBool("ratMovement", false);
                theRB.velocity = new Vector2(0, theRB.velocity.y);             
            }


        if ((Input.GetKey(jump) || value2 > 0) && isGrounded)
        {
            if (gameObject.tag == "Player")
            {
                boyAnim.SetBool("boyNotOnTheFloor", true);
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForcePlayer);


            }
            else if (gameObject.tag == "Rat")
            {
                ratAnim.SetBool("ratNotOnTheFloor", true);
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForceRat);


            }

        }
        else                                                  //Cambios para el planeador *
        if ((Input.GetKey(jump) || value2 > 0))
        {
            theRB.gravityScale = 1.1f;
            moveSpeedPlayer = 10;
        }
        else
        {
            moveSpeedPlayer = 15;                            //*
            theRB.gravityScale = 4.5f;
            boyAnim.SetBool("boyNotOnTheFloor", false);
            ratAnim.SetBool("ratNotOnTheFloor", false);
        }

            if (dead == false)
            {
                if (paused == false)
                {
                    if (theRB.velocity.x < 0)
                    {
                      transform.localScale = new Vector3(-0.3f, 0.25f);
                    }
                    else if (theRB.velocity.x > 0)
                    {
                        transform.localScale = new Vector3(0.3f, 0.25f);
                    }
                }               
            }
        activeMenu();

           
        }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Parets colisio
        if (collision.gameObject.tag == "LeftWall")
        {
            touchingLeftWall = true;
        }
        else if (collision.gameObject.tag == "RightWall")
        {
            touchingRightWall = true;
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            dead = true;
            boyAnim.enabled = false;
            ratAnim.enabled = false;
            theRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            theRB.freezeRotation = true;
            spikes.GetComponent<Spikes>().die(dead);
            pendulum.GetComponent<Pendulum>().die(dead);
            for (int i = 0; i < platforms.transform.childCount; i++)
            {
                platforms.transform.GetChild(i).GetComponent<PlatformMovement>().die(dead);
            }

            for (int i = 0; i < enemies.transform.childCount; i++)
            {
                enemies.transform.GetChild(i).GetComponent<SimpleEnemy>().die(dead);
            }
            GetComponent<SwapPlayer>().enabled = false;
            gameOverAnim.SetBool("isTrigger", true);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
            //Parets colisio
            if (collision.gameObject.tag == "LeftWall")
            {
                touchingLeftWall = false;
            }
            else if (collision.gameObject.tag == "RightWall")
            {
                touchingRightWall = false;
            }


    }

    public void activeMenu()
    {
        if (Input.GetKeyDown(KeyCode.P)|| value3)
        {
            if (pausemenu.activeInHierarchy == true)
            {
                paused = false;
                ratAnim.enabled = true;
                theRB.constraints = originalConstraints;

                for (int i = 0; i < platforms.transform.childCount; i++)
                {
                    platforms.transform.GetChild(i).GetComponent<PlatformMovement>().reset(paused);
                }

                for (int i = 0; i < enemies.transform.childCount; i++)
                {
                    enemies.transform.GetChild(i).GetComponent<SimpleEnemy>().reset(paused);
                }
                GetComponent<SwapPlayer>().enabled = true;
                pausemenu.SetActive(false);
            }
            else if (pausemenu.activeInHierarchy == false)
            {
                paused = true;
                ratAnim.enabled = false;
                originalConstraints = theRB.constraints;
                theRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
                theRB.freezeRotation = true;
                for (int i = 0; i < platforms.transform.childCount; i++)
                {
                    platforms.transform.GetChild(i).GetComponent<PlatformMovement>().reset(paused);
                }

                for (int i = 0; i < enemies.transform.childCount; i++)
                {
                    enemies.transform.GetChild(i).GetComponent<SimpleEnemy>().reset(paused);
                }
                GetComponent<SwapPlayer>().enabled = false;
                pausemenu.SetActive(true);
            }
        }
    }

    public void continueButton()
    {
        pausemenu.SetActive(false);
    }
}










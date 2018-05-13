using System.Collections;
using System.Collections.Generic;
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

    private GameObject enemies;
    private GameObject platforms;

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
    public bool paused = false;
    private RigidbodyConstraints2D originalConstraints;

    public GameObject pausemenu;
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
    }
	
	// Update is called once per frame
	void Update ()
    {
        
            value = Input.GetAxis("Horizontal");
            value2 = Input.GetAxis("Jump");




            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);



            if ((Input.GetKey(left) || value == -1) && touchingLeftWall == false)
            {
                if (gameObject.tag == "Player")
                {
                    theRB.velocity = new Vector2(-moveSpeedPlayer, theRB.velocity.y);
                }
                if (gameObject.tag == "Rat")
                {
                    theRB.velocity = new Vector2(-moveSpeedRat, theRB.velocity.y);
                }

                touchingRightWall = false;
            }
            else if ((Input.GetKey(right) || value == 1) && touchingRightWall == false)
            {
                if (gameObject.tag == "Player")
                {
                    theRB.velocity = new Vector2(moveSpeedPlayer, theRB.velocity.y);
                }
                if (gameObject.tag == "Rat")
                {
                    theRB.velocity = new Vector2(moveSpeedRat, theRB.velocity.y);
                }

                touchingRightWall = false;
            }
            else
            {
                theRB.velocity = new Vector2(0, theRB.velocity.y);
            }


            if ((Input.GetKey(jump) || value2 > 0) && isGrounded)
            {
                if (gameObject.tag == "Player")
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForcePlayer);
                }
                if (gameObject.tag == "Rat")
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForceRat);
                }
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
            ratAnim.enabled = false;
            theRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;

            for (int i = 0; i < platforms.transform.childCount; i++)
            {
                platforms.transform.GetChild(i).GetComponent<PlatformMovement>().die(dead);
            }

            for (int i = 0; i < enemies.transform.childCount; i++)
            {
                enemies.transform.GetChild(i).GetComponent<SimpleEnemy>().die(dead);
            }
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
        if (Input.GetKeyDown(KeyCode.P))
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








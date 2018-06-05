using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private GameObject obstacles;
    private GameObject normal;
    private GameObject gravity;
    private GameObject rocks;
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
    public Animator gameEnding;
    public bool dead = false;

    private bool paused = false;
    private RigidbodyConstraints2D originalConstraints;

    public GameObject pausemenu;
    public bool contin = false;

    public bool onGround;

 
    public int direction = 2;




    // Use this for initialization
    void Start ()
    {
        theRB = GetComponent<Rigidbody2D>();

        boyAnim = boyAnim.GetComponent<Animator>();
        ratAnim = ratAnim.GetComponent<Animator>();
        gameOverAnim = gameOverAnim.GetComponent<Animator>();
        gameEnding = gameEnding.GetComponent<Animator>();

        touchingLeftWall = false;
        touchingRightWall = false;

        enemies = GameObject.Find("Enemies");
        if(GameObject.Find("Platforms").transform.childCount == 2)
        {
            normal = GameObject.Find("Platforms").transform.GetChild(0).gameObject;
            gravity = GameObject.Find("Platforms").transform.GetChild(1).gameObject;

        }
        else
        {
            platforms = GameObject.Find("Platforms");
        }
        obstacles = GameObject.Find("Obstacles");
        spikes =  obstacles.transform.GetChild(0).gameObject;
        rocks = GameObject.Find("RocksObject");
        pendulum = obstacles.transform.GetChild(1).gameObject;

        boyAnim.SetBool("killed", false);
        ratAnim.SetBool("killed", false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //distanceFloor = 
            value = Input.GetAxis("Horizontal");
            value2 = Input.GetAxis("Jump");
            value3 = Input.GetKeyDown("joystick button 7");


        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

        if (!isGrounded)
        {

            boyAnim.SetBool("boyNotOnTheFloor", true);
            ratAnim.SetBool("ratNotOnTheFloor", true);
        }

        if ((Input.GetKey(left) || value == -1) && touchingLeftWall == false)
            {
                if (gameObject.tag == "Player")
                {
                    direction = 1;
                    boyAnim.SetBool("boyMovement", true);
                    theRB.velocity = new Vector2(-moveSpeedPlayer, theRB.velocity.y);
                }
                if (gameObject.tag == "Rat")
                {
                    direction = 1;
                    ratAnim.SetBool("ratMovement", true);
                    theRB.velocity = new Vector2(-moveSpeedRat, theRB.velocity.y);
                }

                touchingRightWall = false;
            }
            else if ((Input.GetKey(right) || value == 1) && touchingRightWall == false)
            {
                if (gameObject.tag == "Player")
                {
                    direction = 2;
                    boyAnim.SetBool("boyMovement", true);
                    theRB.velocity = new Vector2(moveSpeedPlayer, theRB.velocity.y);
                    
                }
                if (gameObject.tag == "Rat")
                {
                    direction = 2;
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
        else if(isGrounded)
        {

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
        if (GameObject.Find("DialogueBox").GetComponent<Animator>().GetBool("IsOpen") && Input.GetKeyDown("joystick button 3"))
        {
            GameObject.Find("DialogueManager").GetComponent<DialogueManager>().DisplayNextSentence();
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "NextLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (collision.gameObject.tag == "Ending")
        {
            gameEnding.SetBool("isTrigger", true);
        }
        //Parets colisio
        if (collision.gameObject.tag == "LeftWall")
        {
            touchingLeftWall = true;
        }
        else if (collision.gameObject.tag == "RightWall")
        {
            touchingRightWall = true;
        }

        if (collision.gameObject.tag == "Floor")
        {
            onGround = true;
        }

        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Enemy")
        {
            dead = true;

            boyAnim.enabled = true;
            ratAnim.enabled = true;

            boyAnim.SetBool("killed", true);
            ratAnim.SetBool("killed", true);

            theRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            theRB.freezeRotation = true;
            for(int i = 0; i < spikes.transform.childCount; i++)
            {
                spikes.transform.GetChild(i).GetComponent<Spikes>().die(dead);
            }
            for(int i = 0; i < pendulum.transform.childCount; i++)
            {
                pendulum.transform.GetChild(i).GetComponent<Pendulum>().die(dead);
            }
            if (GameObject.Find("Platforms").transform.childCount == 2)
            {
                for (int i = 0; i < normal.transform.childCount; i++)
                {
                    normal.transform.GetChild(i).GetComponent<PlatformMovement>().die(dead);
                }
                for (int i = 0; i < gravity.transform.childCount; i++)
                {
                    gravity.transform.GetChild(i).GetComponent<GravityMovement>().die(dead);
                }
            }
            else
            {
                for (int i = 0; i < platforms.transform.childCount; i++)
                {
                    platforms.transform.GetChild(i).GetComponent<PlatformMovement>().die(dead);
                }
            }
            for (int i = 0; i < enemies.transform.childCount; i++)
            {
                if (enemies.transform.GetChild(i).name == "Static")
                {
                    for (int j = 0; j < enemies.transform.GetChild(i).transform.childCount; j++)
                    {
                        enemies.transform.GetChild(i).transform.GetChild(j).GetComponent<StaticEnemy>().die(dead);
                    }
                }
                if (enemies.transform.GetChild(i).GetComponent<SimpleEnemy>() != null)
                {
                    enemies.transform.GetChild(i).GetComponent<SimpleEnemy>().die(dead);
                }
                else
                    if (enemies.transform.GetChild(i).GetComponent<StaticEnemy>() != null)
                {
                    enemies.transform.GetChild(i).GetComponent<StaticEnemy>().die(dead);
                }
            }
            if(rocks!= null)
            {
                for (int i = 0; i < rocks.transform.childCount; i++)
                {
                    rocks.transform.GetChild(i).GetComponent<RockSystem>().die(dead);
                }
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
        if(contin == true)
        {
            paused = false;
            boyAnim.enabled = true;
            ratAnim.enabled = true;
            theRB.constraints = originalConstraints;
            for (int i = 0; i < spikes.transform.childCount; i++)
            {
                spikes.transform.GetChild(i).GetComponent<Spikes>().reset(paused);
            }
            for (int i = 0; i < pendulum.transform.childCount; i++)
            {
                pendulum.transform.GetChild(i).GetComponent<Pendulum>().reset(paused);
            }
            if (GameObject.Find("Platforms").transform.childCount == 2)
            {
                for (int i = 0; i < normal.transform.childCount; i++)
                {
                    normal.transform.GetChild(i).GetComponent<PlatformMovement>().reset(paused);
                }
                for (int i = 0; i < gravity.transform.childCount; i++)
                {
                    gravity.transform.GetChild(i).GetComponent<GravityMovement>().reset(paused);
                }
            }
            else
            {
                for (int i = 0; i < platforms.transform.childCount; i++)
                {
                    platforms.transform.GetChild(i).GetComponent<PlatformMovement>().reset(paused);
                }
            }
            for (int i = 0; i < enemies.transform.childCount; i++)
            {
                if(enemies.transform.GetChild(i).name == "Static")
                {
                    for(int j = 0; j < enemies.transform.GetChild(i).transform.childCount; j++)
                    {
                        enemies.transform.GetChild(i).transform.GetChild(j).GetComponent<StaticEnemy>().reset(paused);
                    }
                }
                if (enemies.transform.GetChild(i).GetComponent<SimpleEnemy>() != null)
                {
                    enemies.transform.GetChild(i).GetComponent<SimpleEnemy>().reset(paused);
                }
                else
                if (enemies.transform.GetChild(i).GetComponent<StaticEnemy>() != null)
                {
                    enemies.transform.GetChild(i).GetComponent<StaticEnemy>().reset(paused);
                }
            }
            if (rocks != null)
            {
                for (int i = 0; i < rocks.transform.childCount; i++)
                {
                    rocks.transform.GetChild(i).GetComponent<RockSystem>().reset(paused);
                }
            }
            GetComponent<SwapPlayer>().enabled = true;
            pausemenu.SetActive(false);
            contin = false;
        }
        if (Input.GetKeyDown(KeyCode.P) || value3)
        {
            if (pausemenu.activeInHierarchy == true)
            {
                paused = false;
                boyAnim.enabled = true;
                ratAnim.enabled = true;
                theRB.constraints = originalConstraints;
                for (int i = 0; i < spikes.transform.childCount; i++)
                {
                    spikes.transform.GetChild(i).GetComponent<Spikes>().reset(paused);
                }
                for (int i = 0; i < pendulum.transform.childCount; i++)
                {
                    pendulum.transform.GetChild(i).GetComponent<Pendulum>().reset(paused);
                }
                if (GameObject.Find("Platforms").transform.childCount == 2)
                {
                    for (int i = 0; i < normal.transform.childCount; i++)
                    {
                        normal.transform.GetChild(i).GetComponent<PlatformMovement>().reset(paused);
                    }
                    for (int i = 0; i < gravity.transform.childCount; i++)
                    {
                        gravity.transform.GetChild(i).GetComponent<GravityMovement>().reset(paused);
                    }
                }
                else
                {
                    for (int i = 0; i < platforms.transform.childCount; i++)
                    {
                        platforms.transform.GetChild(i).GetComponent<PlatformMovement>().reset(paused);
                    }
                }

                for (int i = 0; i < enemies.transform.childCount; i++)
                {
                    if (enemies.transform.GetChild(i).name == "Static")
                    {
                        for (int j = 0; j < enemies.transform.GetChild(i).transform.childCount; j++)
                        {
                            enemies.transform.GetChild(i).transform.GetChild(j).GetComponent<StaticEnemy>().reset(paused);
                        }
                    }
                    if (enemies.transform.GetChild(i).GetComponent<SimpleEnemy>() != null)
                    {
                        enemies.transform.GetChild(i).GetComponent<SimpleEnemy>().reset(paused);
                    }
                    else
                    if (enemies.transform.GetChild(i).GetComponent<StaticEnemy>() != null)
                    {
                        enemies.transform.GetChild(i).GetComponent<StaticEnemy>().reset(paused);
                    }
                }
                if (rocks != null)
                {
                    for (int i = 0; i < rocks.transform.childCount; i++)
                    {
                        rocks.transform.GetChild(i).GetComponent<RockSystem>().reset(paused);
                    }
                }
                GetComponent<SwapPlayer>().enabled = true;
                pausemenu.SetActive(false);
            }
            else if (pausemenu.activeInHierarchy == false)
            {
                paused = true;
                boyAnim.enabled = false;
                ratAnim.enabled = false;
                originalConstraints = theRB.constraints;
                theRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
                theRB.freezeRotation = true;
                for (int i = 0; i < spikes.transform.childCount; i++)
                {
                    spikes.transform.GetChild(i).GetComponent<Spikes>().reset(paused);
                }
                for (int i = 0; i < pendulum.transform.childCount; i++)
                {
                    pendulum.transform.GetChild(i).GetComponent<Pendulum>().reset(paused);
                }
                if (GameObject.Find("Platforms").transform.childCount == 2)
                {
                    for (int i = 0; i < normal.transform.childCount; i++)
                    {
                        normal.transform.GetChild(i).GetComponent<PlatformMovement>().reset(paused);
                    }
                    for (int i = 0; i < gravity.transform.childCount; i++)
                    {
                        gravity.transform.GetChild(i).GetComponent<GravityMovement>().reset(paused);
                    }
                }
                else
                {
                    for (int i = 0; i < platforms.transform.childCount; i++)
                    {
                        platforms.transform.GetChild(i).GetComponent<PlatformMovement>().reset(paused);
                    }
                }

                for (int i = 0; i < enemies.transform.childCount; i++)
                {
                    if (enemies.transform.GetChild(i).name == "Static")
                    {
                        for (int j = 0; j < enemies.transform.GetChild(i).transform.childCount; j++)
                        {
                            enemies.transform.GetChild(i).transform.GetChild(j).GetComponent<StaticEnemy>().reset(paused);
                        }
                    }
                    if (enemies.transform.GetChild(i).GetComponent<SimpleEnemy>() != null)
                    {
                        enemies.transform.GetChild(i).GetComponent<SimpleEnemy>().reset(paused);
                    }
                    else
                    if (enemies.transform.GetChild(i).GetComponent<StaticEnemy>() != null)
                    {
                        enemies.transform.GetChild(i).GetComponent<StaticEnemy>().reset(paused);
                    }
                }
                if (rocks != null)
                {
                    for (int i = 0; i < rocks.transform.childCount; i++)
                    {
                        rocks.transform.GetChild(i).GetComponent<RockSystem>().reset(paused);
                    }
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










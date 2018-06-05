using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatEnemy: MonoBehaviour
{

    public int maxValue = 15;
    public int minValue = -15;
    public bool contacte = false;

    private GameObject ratsos;

    public int speed;

    public int orientation = 0;
    private GameObject PlayerYou;

    private float currentValue = 1;

    private float initialPosX;
    private float initialPosY;

    private float direction = 1;

    private bool deadPlayer = false;

    private bool paused = false;
    private RigidbodyConstraints2D originalConstraints;
    private Rigidbody2D rigidRat;


    public Animator enemyAnim;

    void Start()
    {
        initialPosX = transform.position.x;
        initialPosY = transform.position.y;
        enemyAnim = GetComponent<Animator>();
        PlayerYou = GameObject.Find("Player");
        rigidRat = GetComponent<Rigidbody2D>();
        ratsos = GameObject.Find("Ratsos");
    }


    void Update()
    {
        if (deadPlayer == false)
        {
            //Movement
            if (paused == false)
            {
                currentValue += Time.deltaTime * direction * speed;

                if (currentValue >= maxValue)
                {
                    direction *= -1;
                    currentValue = maxValue;
                }

                else if (currentValue <= minValue)
                {
                    direction *= -1;
                    currentValue = minValue;
                }

                //Horizontal
                if (orientation == 0)
                {
                    transform.position = new Vector3(currentValue + initialPosX, transform.position.y, 0);
                }
                else if (orientation == 1) //Vertical
                {
                    transform.position = new Vector3(transform.position.x, currentValue + initialPosY, 0);
                }


                //Flip
                if (direction > 0)
                {
                    transform.localScale = new Vector3(1f, 1f);
                }
                else if (direction < 0)
                {
                    transform.localScale = new Vector3(-1f, 1f);
                }
            }
        }
        

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        
        if (collision.gameObject.tag == "Player" && PlayerYou.GetComponent<Rigidbody2D>().position.y >= rigidRat.position.y)
            {
            contacte = true;
            //Destroy(this);
            Destroy(this);

            }
        else
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Es el collider");
        }
        else
        if(PlayerYou.GetComponent<Rigidbody2D>().position.y <= rigidRat.position.y)
        {
            Debug.Log("Es la posicion");
        }


    }



public void die(bool deadPlayer)
    {
        this.deadPlayer = deadPlayer;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        enemyAnim.enabled = false;
    }

    public void reset(bool paused)
    {
        this.paused = paused;
        if (paused == false)
        {
            GetComponent<Rigidbody2D>().constraints = originalConstraints;
            enemyAnim.enabled = true;
        }
        else
        {
            originalConstraints = GetComponent<Rigidbody2D>().constraints;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            enemyAnim.enabled = false;
        }
    }
}
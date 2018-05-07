using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
   

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

    


    // Use this for initialization
    void Start ()
    {
        theRB = GetComponent<Rigidbody2D>();

        boyAnim = boyAnim.GetComponent<Animator>();
        ratAnim = ratAnim.GetComponent<Animator>();
        gameOverAnim = gameOverAnim.GetComponent<Animator>();

        touchingLeftWall = false;
        touchingRightWall = false;
    }
	
	// Update is called once per frame
	void Update () {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

		if (Input.GetKey(left) && touchingLeftWall == false)
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
            touchingRightWall = false;
        }
        else if (Input.GetKey(right) && touchingRightWall == false)
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
            touchingLeftWall = false;
        }
        else
        {
            theRB.velocity = new Vector2(0, theRB.velocity.y);
        }

        if (Input.GetKey(jump) && isGrounded)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }

       
        if (theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-0.3f, 0.25f);
        }
        else if (theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(0.3f, 0.25f);
        }
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
}

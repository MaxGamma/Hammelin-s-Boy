using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    /*
    //GameObject Player;
    public float alturaSalto;
    public float velocidadMovimiento;
    bool tierra = false;
    // Use this for initialization
    void Start()
    {
        //  Player = GameObject.Find("Player");
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {

            tierra = true;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.Space) && (tierra == true))
        {
            Saltar();

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(0.4f, 0.3f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadMovimiento, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-0.4f, 0.3f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidadMovimiento, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

    }
    public void Saltar()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,
         alturaSalto);
        tierra = false;
    }
}*/



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

    private Animator anim;


    

	// Use this for initialization
	void Start () {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

		if (Input.GetKey(left))
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
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
            transform.localScale = new Vector3(-0.5f, 0.4f);
        }
        else if (theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(0.5f, 0.4f);
        }

        //anim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));
        //anim.SetBool("Grounded", isGrounded);
	}
}

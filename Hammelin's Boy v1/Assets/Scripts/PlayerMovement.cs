using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
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
            transform.localScale = new Vector3(0.5f, 0.4f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadMovimiento, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-0.5f, 0.4f);
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
}

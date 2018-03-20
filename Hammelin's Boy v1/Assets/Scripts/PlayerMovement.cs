using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {
    //GameObject Player;
    public int nSaltos = 0;
    bool tierra = false;
    // Use this for initialization
    void Start () {
     //  Player = GameObject.Find("Player");
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Tierra True");
            tierra = true;
        }
    }
    // Update is called once per frame
    void FixedUpdate () {
      
            if (Input.GetKey(KeyCode.Space))
            {
                tierra = false;
                   GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
                
            }
            
            if (Input.GetKey(KeyCode.D))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(20, 0));
            }
            if (Input.GetKey(KeyCode.S))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -20));
            }
            if (Input.GetKey(KeyCode.A))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-20, 0));
            }
        //}
       /*else
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0,-10));
 
            saltar = false;
        }*/
    }
   
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMovement : MonoBehaviour {
   
    // Use this for initialization
    void Start () {
        GameObject Rat = GameObject.Find("Rat");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (GameObject.Find("Main Camera").GetComponent<CameraPlayer>().counter % 2 == 1)
        {

            if (Input.GetKey(KeyCode.Space))
            {
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

        }
        else
        {
            transform.position = new Vector3(GameObject.FindWithTag("Player").transform.position.x - 2, GameObject.FindWithTag("Player").transform.position.y - 0.2f, GameObject.FindWithTag("Player").transform.position.z);
        }
        
    }

}

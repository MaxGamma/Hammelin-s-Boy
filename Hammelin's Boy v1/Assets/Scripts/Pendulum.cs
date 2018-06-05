using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour {
    private bool deadPlayer= false;
    private bool paused = false;
    private RigidbodyConstraints2D originalConstraints;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void die(bool deadPlayer)
    {
        this.deadPlayer = deadPlayer;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        GetComponent<Animator>().enabled = false;
    }

    public void reset(bool paused)
    {
        this.paused = paused;
        if (paused == false)
        {
            GetComponent<Rigidbody2D>().constraints = originalConstraints;
            GetComponent<Animator>().enabled = true;
        }
        else
        {
            originalConstraints = GetComponent<Rigidbody2D>().constraints;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            GetComponent<Animator>().enabled = false;
        }
    }
}

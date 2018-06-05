using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMovement : MonoBehaviour {
    bool deadPlayer = false;
    bool paused = false;
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
        GetComponent<Animator>().enabled = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    public void reset(bool paused)
    {
        this.paused = paused;
        if (paused == false)
        {
            GetComponent<Animator>().enabled = true;
            GetComponent<Rigidbody2D>().constraints = GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY; ;
        }
        else
        {
            GetComponent<Animator>().enabled = false;
            originalConstraints = GetComponent<Rigidbody2D>().constraints;
        }
    }

}

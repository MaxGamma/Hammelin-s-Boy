using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class StaticEnemy : MonoBehaviour {

    public GameObject staticEnemy;

    private BoxCollider2D box;
    private Animator animator;

    private float startTime;

    private float time;
    public float changeTimeEyesOn;
    public float changeTimeEyesOff;

    public bool eyesOn = true;

    private bool deadPlayer = false;
    private bool paused = false;

    void Start ()
    {
		box = staticEnemy.GetComponent<BoxCollider2D>();
        animator = staticEnemy.GetComponent<Animator>();
        startTime = Time.time;
    }
	
	
	void Update ()
    {
        if (deadPlayer == false)
        {
            if (paused == false)
            {
                time = (Time.time - startTime) % 60;

                if (time >= changeTimeEyesOn && eyesOn == true)
                {
                    animator.SetBool("EyesOn", false);
                    box.enabled = false;
                    eyesOn = false;
                    startTime = Time.time;
                }
                else if (time >= changeTimeEyesOff && eyesOn == false)
                {
                    animator.SetBool("EyesOn", true);
                    box.enabled = true;
                    eyesOn = true;
                    startTime = Time.time;
                }
            }
        }
	}
    public void die(bool deadPlayer)
    {
        this.deadPlayer = deadPlayer;
        GetComponent<Animator>().enabled = false;
    }
    public void reset(bool paused)
    {
        this.paused = paused;
        if (paused == false)
        {
            GetComponent<Animator>().enabled = true;
        }
        else
        {
            GetComponent<Animator>().enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class StaticEnemy : MonoBehaviour {

    public GameObject staticEnemy;

    private BoxCollider2D box;
    private Animator animator;

    private float startTime;

    public float time;

    public bool eyesOn = true;

    void Start ()
    {
		box = staticEnemy.GetComponent<BoxCollider2D>();
        animator = staticEnemy.GetComponent<Animator>();
        startTime = Time.time;
    }
	
	
	void Update ()
    {
        time = (Time.time - startTime) % 60;

        if (time >= 3.0 && eyesOn == true)
        {
            animator.SetBool("EyesOn", false);
            box.enabled = false;
            eyesOn = false;
            startTime = Time.time;
        }
        else if(time >= 3.0 && eyesOn == false)
        {
            animator.SetBool("EyesOn", true);
            box.enabled = true;
            eyesOn = true;
            startTime = Time.time;
        }
	}
}

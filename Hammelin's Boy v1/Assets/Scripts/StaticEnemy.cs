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
    public float changeTime;

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

        if (time >= changeTime && eyesOn == true)
        {
            animator.SetBool("EyesOn", false);
            box.enabled = false;
            eyesOn = false;
            startTime = Time.time;
        }
        else if(time >= changeTime && eyesOn == false)
        {
            animator.SetBool("EyesOn", true);
            box.enabled = true;
            eyesOn = true;
            startTime = Time.time;
        }
	}
}

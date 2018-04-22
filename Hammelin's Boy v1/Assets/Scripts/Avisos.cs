using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avisos : MonoBehaviour {


    public Animator animator;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            animator.SetBool("isTrigger", true);
        }
    }
}

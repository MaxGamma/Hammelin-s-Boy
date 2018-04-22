using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avisos : MonoBehaviour {


    public Animator animator;

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player" || collider.gameObject.tag == "Rat")
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            animator.SetBool("isTrigger", true);
        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            animator.SetBool("isTrigger", false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour {

    public GameObject endGame;

    Animator animator;

    void Start()
    {
        animator = endGame.GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Rat")
        {
            animator.SetBool("isTrigger", true);
        }
    }
}

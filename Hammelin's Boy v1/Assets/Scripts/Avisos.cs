using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avisos : MonoBehaviour {


    public Animator animator;
    public DialogueTrigger conversation;

    bool isColliding = false;

    void  OnCollisionEnter2D(Collision2D coll)
    {
        

        if (GetComponent<Collider>().gameObject.tag == "Player" || GetComponent<Collider>().gameObject.tag == "Rat")
        {
            isColliding = true;
        }
        else
        {
            isColliding = false;
        }
    }

    void Update()
    {
        if (isColliding == true)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            animator.SetBool("isTrigger", true);
        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            animator.SetBool("isTrigger", false);
        }

        if (gameObject.GetComponent<BoxCollider2D>().isTrigger == true && Input.GetKey(KeyCode.E))
        {
            conversation.TriggerDialogue();
        }
    }
}

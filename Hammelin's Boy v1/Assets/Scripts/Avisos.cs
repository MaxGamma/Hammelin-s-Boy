using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avisos : MonoBehaviour {


    public Animator animator;
    public DialogueTrigger conversation;
    public GameObject paret1;
    public GameObject paret2;

    public Animator ending;

    void Start()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    void  OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            animator.SetBool("isTrigger", true);

            paret1.GetComponent<BoxCollider2D>().enabled = true;
            paret2.GetComponent<BoxCollider2D>().enabled = true;
        }
        


    }

    void Update()
    {
        

        if (gameObject.GetComponent<BoxCollider2D>().enabled == false && Input.GetKey(KeyCode.E))
        {
            conversation.TriggerDialogue();
            /*if (gameObject.Tag = "Ending")
            {
                ending.SetBool(isTrigger, true);
            }*/
        }
    }
}

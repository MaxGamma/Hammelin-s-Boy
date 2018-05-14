using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvisosOut : MonoBehaviour {

    public GameObject aviso;
    public Animator dialogueBox;

    void Start()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        aviso.GetComponent<BoxCollider2D>().enabled = true;
        aviso.GetComponent<Animator>().SetBool("isTrigger", false);

        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        dialogueBox.SetBool("IsOpen", false);

    }
}
    
	
	


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    private CapsuleCollider2D capsule;

    void Start()
    {
        capsule = GetComponent<CapsuleCollider2D>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Rat")
        {
            capsule.enabled = false;
        }


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    private CapsuleCollider2D capsule;
    private bool deadPlayer = false;
    private bool paused = false;
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

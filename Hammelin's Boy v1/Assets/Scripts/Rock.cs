using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

    private float startTime;

    private float time;
    public float deathTime;

    void Start ()
    {
        startTime = Time.time;
	}
	
	void Update ()
    {
        time = (Time.time - startTime) % 60;

        if (time >= deathTime)
        {
            Destroy(gameObject);
        }
    }
}

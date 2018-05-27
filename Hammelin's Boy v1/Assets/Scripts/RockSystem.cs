using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSystem : MonoBehaviour {

    private float startTime;

    private float time;

    public float changeTime;

    public GameObject rock;


    void Start ()
    {
        startTime = Time.time;
    }
	
	
	void Update ()
    {
        time = (Time.time - startTime) % 60;

        if (time >= changeTime )
        {
            Instantiate(rock, new Vector3(Random.Range(-30.0f, -10.0f), transform.position.y, transform.position.z), Quaternion.identity);
            startTime = Time.time;
        }
        
    }
}

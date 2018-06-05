using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSystem : MonoBehaviour {
    private bool deadPlayer = false;
    private bool paused = false;

    private float startTime;

    private float time;

    public float changeTime;
    public int minRange;
    public int maxRange;
    public int height;

    public GameObject rock;


    void Start ()
    {
        startTime = Time.time;
    }
	
	
	void Update ()
    {
        if (deadPlayer == false)
        {
            if (paused == false)
            {
                time = (Time.time - startTime) % 60;

                if (time >= changeTime)
                {
                    Instantiate(rock, new Vector3(Random.Range(minRange, maxRange), height, transform.position.z), Quaternion.identity);
                    startTime = Time.time;
                }
            }
        }
    }
    public void die(bool deadPlayer)
    {
        this.deadPlayer = deadPlayer;
    }
    public void reset(bool paused)
    {
        this.paused = paused;
    }
}

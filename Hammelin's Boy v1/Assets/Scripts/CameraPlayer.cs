using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour {

    public GameObject player;
    public GameObject rat;

    private Vector3 Poffset;
    private Vector3 Roffset;


    public int counter = 0;

    void Start ()
    {
        Poffset = transform.position - player.transform.position;
        Roffset = transform.position - rat.transform.position;
    }
	
	// Update is called once per frame
	void LateUpdate ()
    {
        if (counter % 2 == 0)
        {
           
            transform.position = player.transform.position + Poffset;
        }
        else if (counter % 2 == 1)
        {
            
            transform.position = rat.transform.position + Roffset;
        }
       
    }
}

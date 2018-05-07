using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour {

    public int maxValue = 15; 
    public int minValue = -15; 

    private float currentValue = 1;

    private float initialPos; 

    private float direction = 1;

    void Start ()
    {
        initialPos = transform.position.x;
    }
	
	
	void Update ()
    {     
        currentValue += Time.deltaTime * direction; 

        if (currentValue >= maxValue)
        {
            direction *= -1;
            currentValue = maxValue;
        }

        else if (currentValue <= minValue)
        {
            direction *= -1;
            currentValue = minValue;
        }

        transform.position = new Vector3(currentValue + initialPos, transform.position.y, 0);

        if (direction > 0)
        {
            transform.localScale = new Vector3(-0.3f, 0.25f);
        }
        else if (direction < 0)
        {
            transform.localScale = new Vector3(0.3f, 0.25f);
        }
    }
}

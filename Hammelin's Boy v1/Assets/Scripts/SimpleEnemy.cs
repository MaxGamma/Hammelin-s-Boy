using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour {

    public int maxValue = 15; 
    public int minValue = -15;

    public int orientation = 0;

    private float currentValue = 1;

    private float initialPosX;
    private float initialPosY;

    private float direction = 1;

    private bool deadPlayer = false;

    void Start ()
    {
        initialPosX = transform.position.x;
        initialPosY = transform.position.y;
    }
	
	
	void Update ()
    {
        if (deadPlayer == false)
        {
            //Movement


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

            //Horizontal
            if (orientation == 0)
            {
                transform.position = new Vector3(currentValue + initialPosX, transform.position.y, 0);
            }
            else if (orientation == 1) //Vertical
            {
                transform.position = new Vector3(transform.position.x, currentValue + initialPosY, 0);
            }


            //Flip
            if (direction > 0)
            {
                transform.localScale = new Vector3(-0.3f, 0.3f);
            }
            else if (direction < 0)
            {
                transform.localScale = new Vector3(0.3f, 0.3f);
            }
        }
        
    }

    public void die(bool deadPlayer)
    {
        this.deadPlayer = deadPlayer;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
    }
}

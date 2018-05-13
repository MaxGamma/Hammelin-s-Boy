using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

    public int maxValue = 15;
    public int minValue = -15;

    public float speed;
    public int orientation = 0;

    private float currentValue = 1;

    private float initialPos;

    private float direction = 1;

    private bool deadPlayer = false;

    private float initialPosX;
    private float initialPosY;
    private bool paused = false;
    void Start()
    {
        initialPosX = transform.position.x;
        initialPosY = transform.position.y;
    }


    void Update()
    {
        if (deadPlayer == false)
        {
            //Movement
            if (paused == false)
            {

                currentValue += Time.deltaTime * direction * speed;

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
                    transform.localScale = new Vector3(-0.5f, 0.5f);
                }
                else if (direction < 0)
                {
                    transform.localScale = new Vector3(0.5f, 0.5f);
                }
            }
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
        if(paused == false)
        {
            GetComponent<Animator>().enabled = true;
        }
        else
        {
            GetComponent<Animator>().enabled = false;
        }
    }

}

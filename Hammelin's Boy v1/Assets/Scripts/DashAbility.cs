using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    
    private int direction = 2;


    public DashState dashState;
    public float dashTimer;
    public float maxDash = 20f;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            direction = 1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction = 2;
        }


        switch (dashState)
        {
            case DashState.Ready:

                if (Input.GetKey(KeyCode.K))
                {
                    dashState = DashState.Dashing;
                }
                break;

            case DashState.Dashing:
                dashTimer += Time.deltaTime * 3;
                if (dashTimer >= maxDash)
                {
                    dashTimer = maxDash;

                    if (direction == 1)
                    {
                        rb.velocity = Vector2.left * dashSpeed;
                    }
                    else if (direction == 2)
                    {
                        rb.velocity = Vector2.right * dashSpeed;
                    }

                    dashState = DashState.Cooldown;
                }
                break;
            case DashState.Cooldown:
                dashTimer -= Time.deltaTime;
                if (dashTimer <= 0)
                {
                    dashTimer = 0;
                    dashState = DashState.Ready;
                }
                break;
        }


    }

    public enum DashState
    {
        Ready,
        Dashing,
        Cooldown
    }
}



            
    
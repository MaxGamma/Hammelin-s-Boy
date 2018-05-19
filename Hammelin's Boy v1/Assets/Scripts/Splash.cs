using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour {

    public float time;
    private float startTime;

    public GameObject menuManger;

    void Start()
    {
        startTime = Time.time;
    }


    void Update()
    {
        time = (Time.time - startTime) % 60;
        if (time >= 15.0)
        {
            menuManger.GetComponent<MenuManager>().NextScene();
        }
    }
}

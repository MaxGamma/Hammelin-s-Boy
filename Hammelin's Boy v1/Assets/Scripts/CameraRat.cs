using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRat : MonoBehaviour {

    public GameObject rat;
    private Vector3 Roffset;

    void Start()
    {
        Roffset = transform.position - rat.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Roffset = transform.position - rat.transform.position;
        transform.position = rat.transform.position + Roffset;
    }
}

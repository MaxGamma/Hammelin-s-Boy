using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_ : MonoBehaviour {

    public GameObject pausemenu;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameObject.Find("Main Camera").GetComponent<CameraPlayer>().counter += 1;
        }

        activeMenu();
    }

    public void activeMenu()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (pausemenu.activeInHierarchy == true)
            {
                pausemenu.SetActive(false);
            }
            else if (pausemenu.activeInHierarchy == false)
            {
                pausemenu.SetActive(true);
            }
        }
    }

    public void continueButton()
    {
        pausemenu.SetActive(false);
    }
}

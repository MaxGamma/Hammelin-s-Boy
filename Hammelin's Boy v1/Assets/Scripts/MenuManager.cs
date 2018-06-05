using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PreviousScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void TryAgain()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void Begin()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Continue()
    {
        GameObject.Find("Player").GetComponent<PlayerMovement>().contin = true;
        GameObject.Find("Player").GetComponent<PlayerMovement>().activeMenu();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
    void Update()
    {
        if (SceneManager.GetActiveScene()!= SceneManager.GetSceneByName("Main_Menu")) {
            if (GameObject.Find("Player").GetComponent<PlayerMovement>().pausemenu.activeInHierarchy == true)
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    gameObject.SetActive(true);
                }
                if (Input.GetKeyDown("joystick button 3"))
                {
                    Continue();
                }
                if (Input.GetKeyDown("joystick button 1"))
                {
                    Quit();
                }
                if (Input.GetKeyDown("joystick button 2"))
                {
                    MainMenu();
                }
            }
        }
        else
        {
            if (Input.GetKeyDown("joystick button 3"))
            {
               Begin();
            }
            if (Input.GetKeyDown("joystick button 0"))
            {
                Quit();
            }
        }
        if(GameObject.Find("Player").GetComponent<PlayerMovement>().dead == true)
        {
            if (Input.GetKeyDown("joystick button 1"))
            {
                TryAgain();
            }
            if (Input.GetKeyDown("joystick button 2"))
            {
                MainMenu();
            }
        }
    }


}

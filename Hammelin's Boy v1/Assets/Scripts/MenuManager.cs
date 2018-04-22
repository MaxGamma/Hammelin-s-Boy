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
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
             gameObject.SetActive(true);
        }
    }


}

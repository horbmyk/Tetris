using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class ManagerScene : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene(1);    
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        
        Application.Quit();
    }


    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(1);
        }

    }
}

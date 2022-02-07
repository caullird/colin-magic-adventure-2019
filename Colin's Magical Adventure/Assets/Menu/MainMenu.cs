using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu: MonoBehaviour {

    private void Start()
    {
        
    }
    public void Play()
    {
        SceneManager.LoadScene("Loading");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("VOUS AVEZ QUITTÉ LE JEU");
    }
}

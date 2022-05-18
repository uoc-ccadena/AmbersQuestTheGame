using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;
using UnityEngine.Audio;

public class PauseManager : MonoBehaviour
{
    public GameObject panelOptions;
    public AudioSource clicOptions;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           Invoke("PanelOptions",0); 
        }
    }
    
    public void PanelOptions()
    {
        Time.timeScale = 0;
        panelOptions.SetActive(true);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void Return()
    {
        Time.timeScale = 1;
        panelOptions.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PauseSound()
    {
        clicOptions.Play();
    }

}

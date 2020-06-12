using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public SceneFade sceneFade;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)|| Input.GetKeyDown (KeyCode.P))
        {
            Toggle();
        }
    }
    public void Toggle()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        if (pauseMenu.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    public void Retry()
    {
        Toggle();
        sceneFade.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        Toggle();
        sceneFade.FadeTo("Menu");   
    }
}

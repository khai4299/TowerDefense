using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public SceneFade sceneFade;
    public void Play()
    {
        sceneFade.FadeTo("LevelSelect");
    }
    public void Quit()
    {
        Debug.Log("Quit");
    }
    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        sceneFade.FadeTo("LevelSelect");
    }
}

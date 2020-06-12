using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWin : MonoBehaviour
{
    public string menuScene = "Menu";
    public SceneFade sceneFade;
    public string nextLevel;
    public int levelToUnlock;

    private void OnEnable()
    {
        if (levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
        {
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
        }
        PlayerPrefs.GetInt("levelReached", levelToUnlock);
    }
    public void Continue()
    {
        if (levelToUnlock == 0)
        {
            sceneFade.FadeTo(menuScene);
        }
        else
        {
            sceneFade.FadeTo(nextLevel);
        }
    }
    public void Menu()
    {
        sceneFade.FadeTo(menuScene);
    }
}

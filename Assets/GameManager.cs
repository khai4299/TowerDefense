using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static bool endGame ;
    public GameObject gameOverUI;
    public GameObject gameWinUI;
    private void Start()
    {
        endGame = false;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
            EndGame();
        if (PlayerStats.live <= 0)
        {
            EndGame();
        }
        if (endGame)
            return;
       
    }
    void EndGame()
    {
        endGame = true;
        gameOverUI.SetActive(true);
    }
    public void WinLevel()
    {
        endGame = true;
        gameWinUI.SetActive(true);
    }
}

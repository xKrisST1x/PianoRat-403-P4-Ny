using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverBehavior : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("PianoRunBackup");
        Time.timeScale = 1;
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

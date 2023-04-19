using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehavior : MonoBehaviour
{
    public void startButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void settingsButton()
    {
        // Hide/unhide Settings overlay
    }

    public void quitButton()
    {
        Application.Quit();
    }
}

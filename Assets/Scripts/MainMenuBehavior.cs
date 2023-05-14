using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehavior : MonoBehaviour
{
    [SerializeField]
    Animator ratAnim;

    void Start()
    {
        ratAnim.Play("Dance");
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SettingsButton()
    {
        // Hide/unhide Settings overlay
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    GameObject gameOverlay;

    void Start()
    {
        gameOverlay = GameObject.Find("GameOverlay");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            gameOverlay.SetActive(true);
        }
    }
}

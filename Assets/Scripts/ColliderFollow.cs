using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderFollow : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject gameOverlay;

    float yValue = -3f;

    void Update()
    {
        this.transform.position = new Vector3(player.transform.position.x, yValue, player.transform.position.z);
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

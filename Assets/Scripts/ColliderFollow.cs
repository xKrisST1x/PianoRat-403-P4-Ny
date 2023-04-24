using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderFollow : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    LayerMask playerLayer;

    float yValue = -3f;
    bool gameOver;

    void Update()
    {
        this.transform.position = new Vector3(player.transform.position.x, yValue, player.transform.position.z);

        if (gameOver == true)
        {
            Debug.Log("Dead");
        }
        else
        {
            Debug.Log("Alive");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameOver = true;
        }
    }
}

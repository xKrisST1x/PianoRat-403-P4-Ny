using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialImage : MonoBehaviour
{

  public GameObject imageObject; // Reference to the game object displaying the image

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            imageObject.SetActive(true); // Activate the image object
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            imageObject.SetActive(false); // Deactivate the image object
        }
    }
}


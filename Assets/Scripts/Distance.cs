using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script is based on the following Youtube videos by Jimmy Vegas:
// https://youtu.be/ScxN04YeDj8?list=PLZ1b66Z1KFKit4cSry_LWBisrSbVkEF4t
// https://youtu.be/B0KrgdkEk7M?list=PLZ1b66Z1KFKit4cSry_LWBisrSbVkEF4t

public class Distance : MonoBehaviour
{
    public GameObject disDisplay;
    public int disRun;
    public bool addingDis = false;
    public float disDelay = 0.25f;

    void Update()
    {
        if (addingDis == false)
        {
            addingDis = true;
            StartCoroutine(AddingDis());
        }
    }

    IEnumerator AddingDis()
    {
        disRun += 1;
        disDisplay.GetComponent<Text>().text = "" + disRun;
        yield return new WaitForSeconds(disDelay);
        addingDis = false;
    }
}
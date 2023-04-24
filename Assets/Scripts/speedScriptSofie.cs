using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedScriptSofie : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerSpeed < maximumPlayerSpeed)
        {
            playerSpeed += Time.deltaTime * playerSpeedIncreaseRate;
            gravity = initialGravityValue - playerSpeed;

            if (animator.speed < 1.25f)
            {
                animator.speed += (1 / playerSpeed) * Time.deltaTime;
            }
            //ændre op i animator script!!!!!
        }
    }
}

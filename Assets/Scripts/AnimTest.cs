using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTest : MonoBehaviour
{
    [SerializeField]
    Animator ratAnimator;

    void Start()
    {
        ratAnimator.Play("Slow Run");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

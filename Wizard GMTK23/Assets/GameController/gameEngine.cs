using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameEngine : MonoBehaviour
{
    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = true;

        InputHandler.instance.OnJumpPressed += args => OnMenuPressed();
        InputHandler.instance.OnJumpPressed += args => OnPlayerPressed();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMenuPressed()
    {
        if (isPaused) 
        { 
            isPaused = false;
        }
    }

    private void OnPlayerPressed()
    {
        if (!isPaused)
        {
            isPaused = true;
        }
    }

}

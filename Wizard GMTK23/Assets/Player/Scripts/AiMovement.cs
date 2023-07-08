using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour
{
    public MovementController movementController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Console.WriteLine(movementController._moveInput.ToString());
        movementController._moveInput.x = 1;
    }
}

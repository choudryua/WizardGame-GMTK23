using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AiMovement : MonoBehaviour
{
    [SerializeField]
    private MovementController movementController;
    [SerializeField]
    private GameEngine gameEngine;
    // pos sys
    private Vector2 curDestinationPos;

    [SerializeField]
    private Vector2 destinationCheckSize;
    [SerializeField]
    private Transform destinationCheckTransform;
    [SerializeField]
    private LayerMask destinationLayer;
    [SerializeField]
    private string enemyTag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapBox(destinationCheckTransform.position, destinationCheckSize, 0, destinationLayer))
        {
            MoveCharacter(curDestinationPos);
        }
        
    }

    private void MoveCharacter(Vector2 destination)
    {

    }

    private void LeftRightMovement(int x)
    {
        movementController._moveInput.x = x;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(enemyTag))
        {
            Console.WriteLine("oohnoo :3");
                //gameEngine.reset level();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(destinationCheckTransform.position, destinationCheckSize);
    }
}

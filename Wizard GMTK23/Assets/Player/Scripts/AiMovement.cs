using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Windows;

public class AiMovement : MonoBehaviour
{
    [SerializeField]
    private MovementController movementController;
    [SerializeField]
    private GameEngine gameEngine;
    //room data
    // pos sys
    [SerializeField]
    private Vector2 curDestinationPos;
    [SerializeField]
    private float tolerance;
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
        if (!Physics2D.OverlapBox(destinationCheckTransform.position, destinationCheckSize, 0, destinationLayer))
        {
            Vector3 tempDes = new Vector3(curDestinationPos.x, curDestinationPos.y, 0);
            bool isValid = Math.Abs(this.transform.position.x - tempDes.x) <= tolerance;
            if (!isValid) 
            {
                MoveCharacter(curDestinationPos);

            }
        }
        
    }

    private void MoveCharacter(Vector2 destination)
    {
        float disToX = destination.x - this.transform.position.x;
        if (this.transform.position.x != destination.x)
        {
            if (disToX < 0)
            {
                LeftRightMovement(-1);
            }
            else if (disToX > 0)
            {
                LeftRightMovement(1);
            }
        }
    }

    private void LeftRightMovement(float x)
    {
        print("PWEARSE");
        movementController._moveInput.x = x;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(enemyTag))
        {
            print("oohnoo :3");
                //gameEngine.reset level();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(destinationCheckTransform.position, destinationCheckSize);
    }
}

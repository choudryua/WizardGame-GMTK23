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
    [SerializeField]
    private RoomData roomData;
    //room data
    // pos sys
    [SerializeField]
    private Vector2 curDestinationPos;
    [SerializeField]
    private float tolerance;
    [SerializeField]
    private float toleranceY;
    [SerializeField]
    private Vector2 destinationCheckSize;
    [SerializeField]
    private Transform destinationCheckTransform;
    [SerializeField]
    private LayerMask destinationLayer;
    [SerializeField]
    private string enemyTag;
    [SerializeField]
    private Vector2 curSpawnPoint;
    private float jumpTimeDelay = 3;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        roomData = FindAnyObjectByType<RoomData>();
        timer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        print(gameEngine.roomStart);
        timer += Time.deltaTime;

        if (roomData == null)
        {
            roomData = FindAnyObjectByType<RoomData>();
        }
        try
        {
            curDestinationPos = roomData.currentPlayerGoal;
            curSpawnPoint = roomData.spawnPoint;
        }
        catch(Exception e)
        {
            curDestinationPos = new Vector2(transform.position.x, transform.position.y);
            curSpawnPoint = new Vector2(0, 0);
        }
        if (gameEngine.roomStart == true)
        {
            transform.position = curSpawnPoint;
            gameEngine.roomStart = false;
        }
        if (!Physics2D.OverlapBox(destinationCheckTransform.position, destinationCheckSize, 0, destinationLayer))
        {
            Vector3 tempDes = new Vector3(curDestinationPos.x, curDestinationPos.y, 0);
            bool isValidX = Math.Abs(this.transform.position.x - tempDes.x) <= tolerance;
            bool isValidY = Math.Abs(this.transform.position.y - tempDes.y) <= toleranceY;
            if (!isValidX || !isValidY) 
            {
                MoveCharacter(curDestinationPos);

            }
            else if (isValidX && isValidY)
            {
                try
                {
                    roomData.updateCurGoal(roomData.curRouteListIndex + 1);
                    
                }
                catch (Exception e)
                {
                }
                finally
                {

                }
            }
        }
        else
        {
            print("move to next room");
        }
        
    }

    private void MoveCharacter(Vector2 destination)
    {
        float disToX = destination.x - this.transform.position.x;
        float disToY = destination.y - this.transform.position.y;
        if (disToY > 0)
        {
            if (timer > jumpTimeDelay)
            {
                movementController.Jump();
                timer = 0;
            }
        }
        print(disToX);
        if (disToX < 0)
        {
            LeftRightMovement(-1);
        }
        else if (disToX > 0)
        {
            LeftRightMovement(1);
        }
    }

    private void LeftRightMovement(float x)
    {
        movementController._moveInput.x = x;
        print(movementController._moveInput.x);
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

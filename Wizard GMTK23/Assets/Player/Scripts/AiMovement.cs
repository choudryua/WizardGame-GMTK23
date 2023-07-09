using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class AiMovement : MonoBehaviour
{
    public bool isRespawning;
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
    private float jumpTimeDelay = 1f;
    float timer;
    float freezeYTimer;
    bool isClimbing = false;
    float originalGravity;
    private float isClimbingTimer;
    // Start is called before the first frame update
    void Start()
    {
        isRespawning = false;
        originalGravity = GetComponent<Rigidbody2D>().gravityScale;
        roomData = FindAnyObjectByType<RoomData>();
        timer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (isClimbing)
        {
            isClimbingTimer += Time.deltaTime;
        }
        if (isClimbingTimer > 4 && isClimbing)
        {
            isClimbing = false;
            isClimbingTimer = 0;
        }
        timer += Time.deltaTime;
        freezeYTimer -= Time.deltaTime;
        if (roomData == null)
        {
            roomData = FindAnyObjectByType<RoomData>();
        }
        try
        {
            curDestinationPos = roomData.currentPlayerGoal;
            curSpawnPoint = roomData.spawnPoint;
        }
        catch (Exception e)
        {
            curDestinationPos = new Vector2(transform.position.x, transform.position.y);

            if(FindAnyObjectByType<SceneChanger>().curGameScene == "Level1")
            {
                curSpawnPoint = FindAnyObjectByType<SceneData>().level1Spawn;
            }
            else if (FindAnyObjectByType<SceneChanger>().curGameScene == "Level2")
            {
                curSpawnPoint = FindAnyObjectByType<SceneData>().level2Spawn;
            }
            else if (FindAnyObjectByType<SceneChanger>().curGameScene == "Level3")
            {
                    curSpawnPoint = FindAnyObjectByType<SceneData>().level3Spawn;
            } 
            else
            {
                curSpawnPoint = new Vector3(0,0,0);
            }
        }
        if (gameEngine.roomStart == true)
        {
            try
            {
                transform.position = curSpawnPoint;
                gameEngine.roomStart = false;
            }
            catch (Exception e) { }
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
        }
        if (this.gameObject.GetComponent<Rigidbody2D>().velocity.x == 0 && movementController._moveInput.x > 0)
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(2, 0, 0));
        }
        if (this.gameObject.GetComponent<Rigidbody2D>().velocity.x == 0 && movementController._moveInput.x < 0)
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(-2, 0, 0));
        }
        if (isClimbing)
        {
            MoveUpLadder();
        }
        if (freezeYTimer > 0)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
        if (freezeYTimer == 0)
        {
            GetComponent<Rigidbody2D>().gravityScale = originalGravity;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder") && collision.isTrigger)
        {
            isClimbing = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder") && collision.isTrigger)
        {
            isClimbing= false;
            freezeYTimer = .5f;
        }
        if (collision.gameObject.CompareTag(enemyTag))
        {
            isRespawning = true;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Invoke("ResetLevelAfterDelay", 3);
        }
    }

    private void MoveCharacter(Vector2 destination)
    {
        float disToX = destination.x - this.transform.position.x;
        float disToY = destination.y - this.transform.position.y;
        if (disToY > toleranceY)
        {
            if (timer > jumpTimeDelay)
            {
                movementController.Jump();
                timer = 0;
            }
        }
        if (disToX < -tolerance)
        {
            LeftRightMovement(-1);
        }
        else if (disToX > tolerance)
        {
            LeftRightMovement(1);
        }
    }

    private void MoveUpLadder()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 11);
    }
    private void LeftRightMovement(float x)
    {
        movementController._moveInput.x = x;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(enemyTag))
        {
            isRespawning = true;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Invoke("ResetLevelAfterDelay", 3);
        }
    }
    private void ResetLevelAfterDelay()
    {
        isRespawning = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        FindAnyObjectByType<SceneChanger>().RestartLevel();
        print("oohnoo :3");
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(destinationCheckTransform.position, destinationCheckSize);
    }
}

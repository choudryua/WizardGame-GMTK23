using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class AnimationController : MonoBehaviour
{
    private Animator anim;
    private MovementController movementController;
    private bool animate;
    //declare animations
    [SerializeField]
    private string RUN_ANIMATION = "Run";
    /*    public string FALL_ANIMATION = "Fall";*/
    [SerializeField]
    private string DESPAWN_ANIMATION = "Death";
    [SerializeField]
    private string IDLE_ANIMATION = "Idle";
    private string currentAnimaton;



    [SerializeField]
    private GameObject familiar;

    private bool facingRight;
    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        animate = true;
        currentAnimaton = IDLE_ANIMATION;
        anim = GetComponent<Animator>();
        movementController = GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<AiMovement>().isRespawning)
        {
            animate = false;
            ChangeAnimationState(DESPAWN_ANIMATION);
        }
        else
        {
            animate = true;
        }
        if (animate == true)
        {
            MovePlayerFacing();
            AnimatePlayer();
        }
    }
    void MovePlayerFacing()
    {
        if (movementController._moveInput.x > 0 && facingRight == false)
        {
            Flip();
        }
        else if (movementController._moveInput.x < 0 && facingRight == true)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;

        facingRight = !facingRight;
    }
    void AnimatePlayer()
    {
        if(movementController._moveInput.x > 0 || movementController._moveInput.y < 0 || GetComponent<Rigidbody2D>().velocity.y > 0) 
        {
            ChangeAnimationState(RUN_ANIMATION);
        }
        else
        {
            ChangeAnimationState(IDLE_ANIMATION);
        }
    }
    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        anim.Play(newAnimation);
        currentAnimaton = newAnimation;
    }
}

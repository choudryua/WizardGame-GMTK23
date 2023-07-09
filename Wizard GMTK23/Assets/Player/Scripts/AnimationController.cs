using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator anim;
    private MovementController movementController;
    private bool animate;
    //declare animations
    public string RUN_ANIMATION = "Run";
    /*    public string FALL_ANIMATION = "Fall";*/
    public string DESPAWN_ANIMATION = "Death";
    public string IDLE_ANIMATION = "Idle";
    public string currentAnimaton;

    // Start is called before the first frame update
    void Start()
    {
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
            AnimatePlayer();
        }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using System.Diagnostics;

public class InputHandler : MonoBehaviour
{
    public static InputHandler instance;

    private Controls controls;

    //debug Objects needed here
    //game control needed here
    [Header("Input Values")]

    //player Inputs
    public Action<InputArgs> OnMenuPressed; //to menu

    private float moveInput; //movement

    public Action<InputArgs> OnJumpPressed; //jump
    public Action<InputArgs> OnJumpReleased;

    public Action<InputArgs> OnCrouchPressed; //crouch
    public Action<InputArgs> OnCrouchReleased;

    public Action<InputArgs> OnInteractPressed; //Interact
    public Action<InputArgs> OnInteractReleased;

    //menu inputs
    public Action<InputArgs> OnPlayerPressed; //to player

    public Action<InputArgs> OnBackPressed; //back

    public Action<InputArgs> OnSelectPressed; //Select

    public Action<InputArgs> OnUpPressed; //up

    public Action<InputArgs> OnDownPressed; //down

    public Action<InputArgs> OnLeftPressed; //Left

    public Action<InputArgs> OnRightPressed; //right


    // Start is called before the first frame update
    void Awake()
    {
        //get debugger and gameControl here

        #region Singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        #endregion
        controls = new Controls();

        #region Assign Inputs

        #region player
        //controls.(actionmap).(action).performed += ctx => On(actionpressed/released)(new InputArgs { context = ctx});
        controls.Player.Menu.performed += ctx => OnMenuPressed(new InputArgs { context = ctx }); //menu

        controls.Player.Movement.performed += ctx => moveInput = ctx.ReadValue<float>(); //movement
        controls.Player.Movement.canceled += ctx => moveInput = 0;

        controls.Player.Jump.performed += ctx => OnJumpPressed(new InputArgs { context = ctx }); //jump
        controls.Player.JumpUp.performed += ctx => OnJumpReleased(new InputArgs { context = ctx });

        controls.Player.Crouch.performed += ctx => OnCrouchPressed(new InputArgs { context = ctx }); //crouch
        controls.Player.CrouchUp.performed += ctx => OnCrouchReleased(new InputArgs { context = ctx });

        controls.Player.Interact.performed += ctx => OnInteractPressed(new InputArgs { context = ctx }); //interact
        controls.Player.InteractUp.performed += ctx => OnInteractReleased(new InputArgs { context = ctx });
        #endregion

        #region Menu
/*        controls.Menu.Player.performed += ctx => OnPlayerPressed(new InputArgs { context = ctx }); //jump

        controls.Menu.Back.performed += ctx => OnBackPressed(new InputArgs { context = ctx }); //Back

        controls.Menu.Select.performed += ctx => OnSelectPressed(new InputArgs { context = ctx }); //Select

        controls.Menu.Up.performed += ctx => OnUpPressed(new InputArgs { context = ctx }); //Up

        controls.Menu.Down.performed += ctx => OnDownPressed(new InputArgs { context = ctx }); //Down

        controls.Menu.Left.performed += ctx => OnLeftPressed(new InputArgs { context = ctx }); //Left

        controls.Menu.Right.performed += ctx => OnRightPressed(new InputArgs { context = ctx }); //Right*/
        #endregion

        #endregion

/*        instance.controls.Player.Enable();
        instance.controls.Menu.Disable();*/
    }

    // Update is called once per frame
    void Update()
    {
        //if player
            //instance.controls.Player.Enable();
            //instance.controls.Menu.Disable();
        //if menu
            //instance.controls.Menu.Enable();
            //instance.controls.Player.Disable();
    }

    #region Properties
    public float MoveInput
    {
        get
        {
            return moveInput;
        }
    }
    #endregion

    #region Events
    public class InputArgs
    {
        public InputAction.CallbackContext context;
    }

    #endregion

    #region OnEnable/OnDisable
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
    #endregion
}

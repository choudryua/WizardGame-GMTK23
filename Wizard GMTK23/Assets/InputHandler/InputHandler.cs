using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using System.Diagnostics;

public class InputHandler : MonoBehaviour
{
    public static InputHandler instance;

    public GameEngine gameEngine;
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

    //familear inputs
    public Action<InputArgs> OnShootPressed; //shoot

    private Vector2 onMove; //shoot
    // Start is called before the first frame update
    void Awake()
    {
        gameEngine = FindFirstObjectByType<GameEngine>();
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

        /*        #region player
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
                #endregion*/

        #region Menu
        controls.Menu.Player.performed += ctx => OnPlayerPressed(new InputArgs { context = ctx }); //switch to player from menu

        controls.Menu.Back.performed += ctx => OnBackPressed(new InputArgs { context = ctx }); //Back

        controls.Menu.Select.performed += ctx => OnSelectPressed(new InputArgs { context = ctx }); //Select

        controls.Menu.Up.performed += ctx => OnUpPressed(new InputArgs { context = ctx }); //Up

        controls.Menu.Down.performed += ctx => OnDownPressed(new InputArgs { context = ctx }); //Down

        controls.Menu.Left.performed += ctx => OnLeftPressed(new InputArgs { context = ctx }); //Left

        controls.Menu.Right.performed += ctx => OnRightPressed(new InputArgs { context = ctx }); //Right
        #endregion

        #region Familar
        controls.Familar.Menu.performed += ctx => OnMenuPressed(new InputArgs { context = ctx }); //to menu
        controls.Familar.Menu.performed += ctx => OnShootPressed(new InputArgs { context = ctx }); // shoot
        #endregion

        #endregion

        instance.controls.Menu.Disable();
        instance.controls.Familar.Enable();
/*        instance.controls.Player.Disable();*/
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEngine.isPaused)
        {
            instance.controls.Familar.Disable();
            instance.controls.Menu.Enable();
        }
        else if (!gameEngine.isPaused) 
        {
            instance.controls.Familar.Enable();
            instance.controls.Menu.Disable();
        }
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

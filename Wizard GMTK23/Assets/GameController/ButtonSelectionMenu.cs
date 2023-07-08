using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSelectionMenu : MonoBehaviour
{
    public bool mainMenu;
    public GameObject curButton;
    public string curButtonString;
    public bool canMove;
    public bool onPauseStart;
    void Start()
    {
        /*        if (mainMenu)
                {
                    curButton = GameObject.Find("MainEventSystem").GetComponent<EventSystem>().firstSelectedGameObject;
                }
                if(mainMenu == false)
                {
                    curButton = GameObject.Find("PauseEventSystem").GetComponent<EventSystem>().firstSelectedGameObject;
                }*/
        InputHandler.instance.OnUpPressed += args => OnUp(args);
        InputHandler.instance.OnDownPressed += args => OnDown(args);
        InputHandler.instance.OnSelectPressed += args => OnSelect(args);
        InputHandler.instance.OnBackPressed += args => OnBack(args);
        InputHandler.instance.OnLeftPressed += args => OnLeft(args);
        InputHandler.instance.OnRightPressed += args => OnRight(args);
    }
    void Update()
    {
/*        if (mainMenu == false && onPauseStart)
        {
            curButton = GameObject.Find("PauseEventSystem").GetComponent<EventSystem>().firstSelectedGameObject;
            curButtonString = curButton.name;
            onPauseStart = false;
        }*/
        if (curButton == null && mainMenu)
        {
            curButton = GameObject.Find("MainEventSystem").GetComponent<EventSystem>().firstSelectedGameObject;
        }
        else if (curButton == null)
        {
            curButton = GameObject.Find("PauseEventSystem").GetComponent<EventSystem>().firstSelectedGameObject;
        }
        curButtonString = curButton.name;
    }
    void OnUp(InputHandler.InputArgs args)
    {
        Debug.Log("up");
        curButton.GetComponent<ButtonManager>().OnUp();
        return;

    }
    void OnDown(InputHandler.InputArgs args)
    {
        Debug.Log("down");
        curButton.GetComponent<ButtonManager>().OnDown();
        return;

    }
    void OnSelect(InputHandler.InputArgs args)
    {
        Debug.Log("select");

        curButton.GetComponent<ButtonManager>().OnRight();
        return;

    }
    void OnBack(InputHandler.InputArgs args)
    {
        Debug.Log("back");

        curButton.GetComponent<ButtonManager>().OnLeft();
        return;

    }
    void OnLeft(InputHandler.InputArgs args)
    {
        return;
    }
    void OnRight(InputHandler.InputArgs args)
    {
        return;
    }
}

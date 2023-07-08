using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    public ButtonSelectionMenu menu;
    public Sprite spriteStateDefault;
    public GameObject upButton;
    public GameObject downButton;
    public GameObject leftButton;
    public GameObject rightButton;

    public bool inMainMenu;
    public int ping;
    public bool canGoUp;
    public bool canGoDown;
    public bool canGoLeft;
    public bool canGoRight;
    public bool canDoRight;
    void Start()
    {
        spriteStateDefault = this.GetComponent<Image>().sprite;
        #region checks
        //bad code but didnt want this to take too many lines
        if (upButton == null)
        {
            canGoUp = false;
        }
        else if (upButton.GetComponent<Button>() != null)
        {
            canGoUp = true;
        }
        else
        {
            canGoUp = false;
        }

        if (downButton == null)
        {
            canGoDown = false;
        }
        else if (downButton.GetComponent<Button>() != null)
        {
            canGoDown = true;
        }
        else
        {
            canGoDown = false;
        }

        if (leftButton == null)
        {
            canGoLeft = false;
        }
        else if (leftButton.GetComponent<Button>() != null)
        {
            canGoLeft = true;
        }
        else
        {
            canGoLeft = false;
        }

        if (rightButton == null)
        {
            canGoRight = false;
        }
        else if (rightButton.GetComponent<Button>() != null && canDoRight == false)
        {
            canGoRight = true;
            canDoRight = false;
        }
        else
        {
            canGoRight = false;
            canDoRight = true;
        }
        /*        Checks(upButton , canGoUp);
                Checks(downButton, canGoDown);
                Checks(leftButton, canGoLeft);
                Checks(rightButton, canGoRight);*/
        #endregion
    }
    /*    private void Checks(GameObject direction, bool canGo)
        {
            if (direction == null)
            {
                canGo = false;
            }
            else
            {
                canGo = true;
            }

        }*/
    // Update is called once per frame
    void Update()
    {
        ping = 1;
        if (menu == null && inMainMenu)
        {
            menu = GameObject.Find("MainMenuInput").GetComponent<ButtonSelectionMenu>();
        }
        if (menu == null && inMainMenu == false)
        {
            menu = GameObject.Find("MainMenuInput").GetComponent<ButtonSelectionMenu>();
        }
        if (menu.curButtonString == this.name)
        {
            SpriteState spriteState = new SpriteState();
            spriteState = this.GetComponent<Button>().spriteState;
            this.GetComponent<Button>().image.sprite = spriteState.highlightedSprite;
        }
        else
        {
            this.GetComponent<Button>().image.sprite = spriteStateDefault;
        }
    }
    public void OnUp()
    {

        Debug.Log("up");
        if (canGoUp)
        {
            Debug.Log("up");
            menu.curButton = upButton;
        }
    }
    public void OnDown()
    {
        Debug.Log("down1");
        if (canGoDown)
        {
            Debug.Log("down2");

            menu.curButton = downButton;
        }
    }
    public void OnLeft()
    {
        Debug.Log("left");
        if (canGoLeft)
        {
            Debug.Log("left");
            menu.curButton = leftButton;
        }
    }
    public void OnRight()
    {

        Debug.Log("reight");
        if (canGoRight)
        {
            Debug.Log("reight");
            menu.curButton = rightButton;
        }
        else if (canDoRight)
        {
            Debug.Log("menu changed");
            menu.curButton.GetComponent<Button>().onClick.Invoke();
        }

    }
}

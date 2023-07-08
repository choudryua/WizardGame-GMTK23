using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnpauseButton : MonoBehaviour
{
    private GameEngine gameEngine;
    // Start is called before the first frame update
    void Start()
    {
        gameEngine = FindFirstObjectByType<GameEngine>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Console.WriteLine("awfawfawf");
        OnClick();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnClick()
    {
        gameEngine.OnPlayerPressed();
    }
}

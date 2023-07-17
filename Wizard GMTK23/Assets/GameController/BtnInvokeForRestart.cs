using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnInvokeForRestart : MonoBehaviour
{
    [SerializeField]
    private AiMovement playerController;
    [SerializeField]
    private GameEngine gameEngine;
    // Start is called before the first frame update
    void Start()
    {
        if (playerController == null)
        {
            playerController = FindFirstObjectByType<AiMovement>();
        }
        if (gameEngine == null)
        {
            gameEngine = FindFirstObjectByType<GameEngine>();
        }
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
        playerController.Respawn();
    }
}

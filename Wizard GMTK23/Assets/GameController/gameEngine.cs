using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    private bool isPaused;
    public bool isMainMenu;
    public Pause pauseManager;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = true;
        pauseManager.PauseGame();
        InputHandler.instance.OnJumpPressed += args => OnMenuPressed();
        InputHandler.instance.OnJumpPressed += args => OnPlayerPressed();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GameStart()
    {
        isPaused = false;
        pauseManager.UnPauseGame();
    }
    private void OnMenuPressed()
    {
        if (isPaused && !isMainMenu) 
        {
            pauseManager.OnPauseMenu();
            isPaused = false;
        }
    }

    private void OnPlayerPressed()
    {
        if (!isPaused && !isMainMenu)
        {
            pauseManager.UnPauseMenu();
            isPaused = true;
        }
    }

}

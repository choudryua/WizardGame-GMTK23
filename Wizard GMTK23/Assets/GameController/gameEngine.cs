using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    public bool isPaused;
    public bool testing;
    public bool isMainMenu;
    public Pause pauseManager;
    // Start is called before the first frame update
    void Start()
    {
        if (!testing){
            isPaused = true;
            pauseManager.PauseGame();
        }
        else if (testing)
        {
            isPaused = false;
            pauseManager.UnPauseGame();
        }
        InputHandler.instance.OnMenuPressed += args => OnMenuPressed();
        InputHandler.instance.OnPlayerPressed += args => OnPlayerPressed();
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
        if (!isPaused && !isMainMenu) 
        {
            pauseManager.OnPauseMenu();
            isPaused = true;
        }
    }

    public void OnPlayerPressed()
    {
        if (isPaused && !isMainMenu)
        {
            pauseManager.UnPauseMenu();
            isPaused = false;
        }
    }

}

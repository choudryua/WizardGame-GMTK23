using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEngine : MonoBehaviour
{
    public GameObject player;
    public GameObject familar;
    public bool isPaused;
    public bool testing;
    public bool isMainMenu;
    public Pause pauseManager;
    public bool mainMenuUnloaded;
    // Start is called before the first frame update
    void Start()
    {
        if (!testing){
            player.GetComponent<Renderer>().enabled = false;
            familar.GetComponent<Renderer>().enabled = false;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            isPaused = true;
            isMainMenu = true;
            mainMenuUnloaded = false;
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
        if (!isMainMenu && !mainMenuUnloaded)
        {
            SceneManager.UnloadSceneAsync("MainMenu");
            mainMenuUnloaded = true;
        }
    }

    public void GameStart()
    {
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        isPaused = false;
        player.GetComponent<Renderer>().enabled = true;
        familar.GetComponent<Renderer>().enabled = true;
        isMainMenu = false;
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

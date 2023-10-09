using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEngine : MonoBehaviour
{
    private SceneChanger sceneManager;
    public GameObject player;
    public GameObject familar;
    public bool isPaused;
    public bool testing;
    public bool isMainMenu;
    public Pause pauseManager;
    public bool mainMenuUnloaded;
    public bool roomStart;

    public GameObject EndScreenPanel;
    public GameObject EventManager;
    // Start is called before the first frame update
    void Start()
    {
        if(sceneManager== null)
        {
            sceneManager = GetComponent<SceneChanger>();
        }
        pauseManager = FindAnyObjectByType<Pause>();
        if (!testing){
            CharGameStart();
        }
        else if (testing)
        {
            roomStart = true;
            isPaused = false;
            pauseManager.UnPauseGame();
        }
        InputHandler.instance.OnMenuPressed += args => OnMenuPressed();
        InputHandler.instance.OnPlayerPressed += args => OnPlayerPressed();
        InputHandler.instance.OnRestartPressed += args => OnRestartPressed();
    }

    public void CharGameStart()
    {
        player.GetComponent<Renderer>().enabled = false;
        familar.GetComponent<Renderer>().enabled = false;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        isPaused = true;
        isMainMenu = true;
        mainMenuUnloaded = false;
        roomStart = true;
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
        player.SetActive(true);
        player.GetComponent<Renderer>().enabled = true;
        familar.GetComponent<Renderer>().enabled = true;
        Invoke("InvokeRoomStart",1);
    }
    public void InvokeRoomStart()
    {
        isPaused = false;
        isMainMenu = false;
        roomStart = true;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
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

    public void OnRestartPressed()
    {
        player.GetComponent<AiMovement>().Respawn();
    }

    public void StartEndScreen()
    {
        pauseManager.PauseGame();
        EventManager.SetActive(true);
        EndScreenPanel.SetActive(true);
    }
    public void StartMainMenu()
    {
        EventManager.SetActive(false);
        EndScreenPanel.SetActive(false);
        GameStart();
        sceneManager.LoadMainMenu();
    }
}

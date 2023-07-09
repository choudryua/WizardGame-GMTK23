using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.Android.LowLevel;
using UnityEngine.Rendering;
using System;
using Unity.PlasticSCM.Editor.WebApi;

public class SceneChanger : MonoBehaviour
{
    public GameEngine gameEngine;

    [SerializeField]
    private string mainMenuScene;
    [SerializeField]
    private string pauseMenuScene;
    [SerializeField]
    private bool testing;
    [SerializeField]
    private string curGameScene;
    private void Start()
    {
        if(!testing)
        {
            SceneManager.LoadScene(mainMenuScene, LoadSceneMode.Additive);
        }
    }
    void Update()
    {

    }
    public void OnClick(string newScene)
    {
        print("please");
        SceneSelect(newScene);
    }
    public void SceneSelect(string sceneToChangeTo)
    {
        gameEngine = FindAnyObjectByType<GameEngine>();
        if (sceneToChangeTo == "Level1")
        {
            gameEngine.GameStart();
        }
        Console.WriteLine(SceneManager.sceneCount);
        SceneManager.LoadScene(sceneToChangeTo, LoadSceneMode.Additive);
        try
        {
            SceneManager.UnloadSceneAsync(curGameScene);
        }
        catch(Exception e)
        {

        }
        curGameScene = sceneToChangeTo;
        print(curGameScene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        print(curGameScene);
        SceneManager.UnloadSceneAsync(curGameScene);
        SceneManager.LoadScene(curGameScene);
    }
}

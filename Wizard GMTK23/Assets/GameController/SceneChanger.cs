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
        gameEngine.roomStart = true;
        print("scene select ran");
        gameEngine = FindAnyObjectByType<GameEngine>();
        if (sceneToChangeTo == "Level1")
        {
            gameEngine.roomStart = true;
            SceneManager.LoadSceneAsync(sceneToChangeTo, LoadSceneMode.Additive);
            curGameScene = sceneToChangeTo;
            gameEngine.roomStart = true;
            gameEngine.GameStart();
        }
        else
        {
            StartCoroutine(SceneSwitchFromObj(sceneToChangeTo));
        }
    }
    IEnumerator SceneSwitchFromObj(string sceneToChangeTo)
    {
        gameEngine.roomStart = true;
        AsyncOperation load = SceneManager.UnloadSceneAsync(curGameScene);
        yield return load;
        SceneManager.LoadSceneAsync(sceneToChangeTo, LoadSceneMode.Additive);
        curGameScene = sceneToChangeTo;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        print("restart ran");
        print(curGameScene);
        StartCoroutine("SceneSwitch");
    }

    IEnumerator SceneSwitch()
    {
        AsyncOperation load = SceneManager.UnloadSceneAsync(curGameScene);
        yield return load;
        SceneManager.LoadSceneAsync(curGameScene, LoadSceneMode.Additive);
        gameEngine.roomStart = true;
    }

}

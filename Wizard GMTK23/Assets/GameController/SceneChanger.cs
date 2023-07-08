using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.Android.LowLevel;
using UnityEngine.Rendering;
using System;

public class SceneChanger : MonoBehaviour
{
    private gameEngine gameEngine;

    [SerializeField]
    private string mainMenuScene;
    [SerializeField]
    private string pauseMenuScene;
    [SerializeField]
    private bool testing;

    private void Start()
    {
        if(!testing)
        {
            SceneManager.LoadScene(mainMenuScene, LoadSceneMode.Additive);
            SceneManager.LoadScene(pauseMenuScene, LoadSceneMode.Additive);
        }
    }
    void Update()
    {

    }
    public void OnClick(string newScene)
    {
        SceneSelect(newScene);
    }
    public void SceneSelect(string sceneToChangeTo)
    {
        Console.WriteLine("THAFHWFAH");
        SceneManager.LoadScene(sceneToChangeTo, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(2));
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}

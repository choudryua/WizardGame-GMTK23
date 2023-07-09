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
    public Rigidbody2D playerRG;
    [SerializeField]
    private string mainMenuScene;
    [SerializeField]
    private string pauseMenuScene;
    [SerializeField]
    private bool testing;
    [SerializeField]
    public string curGameScene;
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
        playerRG.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
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
        AsyncOperation load = SceneManager.UnloadSceneAsync(curGameScene);
        yield return load;
        SceneManager.LoadSceneAsync(sceneToChangeTo, LoadSceneMode.Additive);
        curGameScene = sceneToChangeTo;
        yield return new WaitForSeconds(1);
        gameEngine.roomStart = true;
        yield return new WaitForSeconds(1);
        playerRG.velocity = new Vector3(0,0,0);
        playerRG.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        playerRG.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
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

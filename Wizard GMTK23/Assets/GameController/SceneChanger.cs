using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneSelect(newScene);
    }
    public void SceneSelect(string sceneToChangeTo)
    {
        playerRG.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        gameEngine = FindAnyObjectByType<GameEngine>();
        if (sceneToChangeTo == "Level1")
        {
            StartCoroutine(Level1Switching("Level1"));
        }
        else
        {
            StartCoroutine(SceneSwitchFromObj(sceneToChangeTo));
        }
    }
    IEnumerator SceneSwitchFromObj(string sceneToChangeTo)
    {
        playerRG.velocity = new Vector3(0, 0, 0);
        gameEngine.roomStart = true;
        AsyncOperation unLoad = SceneManager.UnloadSceneAsync(curGameScene);
        yield return unLoad;
        AsyncOperation load = SceneManager.LoadSceneAsync(sceneToChangeTo, LoadSceneMode.Additive);
        yield return load;
        curGameScene = sceneToChangeTo;
        gameEngine.roomStart = true;
        playerRG.velocity = new Vector3(0,0,0);
        playerRG.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        playerRG.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    IEnumerator Level1Switching(string sceneToChangeTo)
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(sceneToChangeTo, LoadSceneMode.Additive);
        yield return load;
        curGameScene = sceneToChangeTo;
        gameEngine.roomStart = true;
        gameEngine.GameStart();
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

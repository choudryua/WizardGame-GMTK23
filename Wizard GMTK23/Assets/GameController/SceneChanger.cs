using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.Android.LowLevel;
using UnityEngine.Rendering;

public class SceneChanger : MonoBehaviour
{
    private GameObject debugObject;
    private gameEngine gameEngine;

    private bool clicked;

    [SerializeField]
    private FamilarMovementController playerController;

    [SerializeField]
    private Button relatedUiButton;
    [SerializeField]
    private bool isUiButton;
    [SerializeField]
    private bool isGameInteractable;

    [SerializeField]
    private Scene curScene;

    [SerializeField]
    private string sceneToTransition;

    [SerializeField]
    public Transform InteractCheckPoint;
    [SerializeField] 
    public Vector2 InteractCheckSize;
    [SerializeField] 
    public LayerMask CameraLayer;

    private void Start()
    {
        clicked = false;
        curScene = SceneManager.GetActiveScene();
        debugObject = GameObject.FindGameObjectWithTag("Debugger");
        gameEngine = debugObject.GetComponent<gameEngine>();
    }
    void Update()
    {
        if (isGameInteractable)
        {
            if (Physics2D.OverlapBox(InteractCheckPoint.position, InteractCheckSize, 0, CameraLayer))
            {
                if (playerController.isInteracting == true)
                {
                    SceneSelect();
                }
            }
        }
        else if (isUiButton && clicked)
        {
            relatedUiButton.onClick.AddListener(OnClick);
        }
    }
    private void OnClick()
    {
        clicked = true;
        SceneSelect();
    }
    public void SceneSelect()
    {
        SceneManager.LoadScene(sceneToTransition, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(2));
    }
    public void OnGameStart()
    {
        SceneManager.LoadScene(sceneToTransition, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("MainMenu");
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
    }
/*    public void OnDrawGizmos()
    {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(InteractCheckPoint.position, InteractCheckSize);
    }*/
    public void QuitGame()
    {
        Application.Quit();
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelChangeToWinScreen : MonoBehaviour
{
    private SceneChanger sceneChanger;
    private GameEngine gameEngine;
    [SerializeField]
    public string sceneToChangeTo;
    [SerializeField]
    private string playerTag;
    private bool hasSwitched;
    // Start is called before the first frame update
    void Start()
    {
        hasSwitched = false;
        sceneChanger = FindFirstObjectByType<SceneChanger>();
        gameEngine = FindFirstObjectByType<GameEngine>();
    }
    private void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Console.WriteLine("awfawfawf");
        OnClick();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnClick()
    {
        Console.WriteLine("awf afdfasdfawfawf");
        gameEngine.CharGameStart();
        gameEngine.StartMainMenu();
    }


    // DESTROY FIREBALL
    private void destroyFireBall()
    {
        if (GameObject.Find("FireBall(Clone)") != null)
        {
            Destroy(GameObject.Find("FireBall(Clone)"));
        }
    }
}

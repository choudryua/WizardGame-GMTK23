using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RestartGameScript : MonoBehaviour
{
    private SceneChanger sceneChanger;
    private GameEngine gameEngine;
    [SerializeField]
    public string sceneToChangeTo;
    // Start is called before the first frame update
    void Start()
    {
        gameEngine = FindFirstObjectByType<GameEngine>();
        sceneChanger = FindFirstObjectByType<SceneChanger>();
    }

    // Update is called once per frame
    void Update()
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
        sceneChanger.SceneSelect(sceneToChangeTo);
        destroyFireBall();
    }

    private void destroyFireBall()
    {
        if (GameObject.Find("FireBall(Clone)") != null)
        {
            Destroy(GameObject.Find("FireBall(Clone)"));
        }
    }
}

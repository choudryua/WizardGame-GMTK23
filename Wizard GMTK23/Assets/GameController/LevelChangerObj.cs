using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelChangerObj : MonoBehaviour
{
    private SceneChanger sceneChanger;
    [SerializeField]
    public string sceneToChangeTo;
    [SerializeField]
    private string playerTag;
    // Start is called before the first frame update
    void Start()
    {
        sceneChanger = FindFirstObjectByType<SceneChanger>();

    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.isTrigger)
        {
            print("To next room");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            sceneChanger.SceneSelect(sceneToChangeTo);
        }
    }
    public void OnClick()
    {
    }
}

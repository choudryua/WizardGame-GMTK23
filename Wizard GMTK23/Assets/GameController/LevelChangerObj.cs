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
    private bool hasSwitched;
    [SerializeField]
    private Vector2 checkSize;
    [SerializeField]
    private LayerMask playerLayer;
    // Start is called before the first frame update
    void Start()
    {
        hasSwitched= false;
        sceneChanger = FindFirstObjectByType<SceneChanger>();

    }
    private void Update()
    {
        if (Physics2D.OverlapBox(transform.position, checkSize, 0, playerLayer) && hasSwitched == false)
        {
            hasSwitched = true;
            sceneChanger.SceneSelect(sceneToChangeTo);
        }
    }
    // Update is called once per frame
/*    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag) && !hasSwitched)
        {
            hasSwitched = true;
            sceneChanger.SceneSelect(sceneToChangeTo);
        }
    }*/
/*    private void OnCollisionExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag) && !hasSwitched)
        {
            hasSwitched = true;
            sceneChanger.SceneSelect(sceneToChangeTo);
        }
    }*/
    public void OnClick()
    {
    }
}

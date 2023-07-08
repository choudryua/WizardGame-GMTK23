using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonData : MonoBehaviour
{
    private SceneChanger sceneChanger;
    [SerializeField]
    public string sceneToChangeTo;
    // Start is called before the first frame update
    void Start()
    {
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
        Console.WriteLine("awf afdfasdfawfawf");
        sceneChanger.SceneSelect(sceneToChangeTo);
    }
}

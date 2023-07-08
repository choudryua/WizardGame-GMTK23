using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField]
    private Canvas thisCanvas;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Awake()
    {
        thisCanvas.worldCamera = FindAnyObjectByType<Camera>();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
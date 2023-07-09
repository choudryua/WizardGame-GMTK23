using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FamilarMovementController : MonoBehaviour
{
    public bool isInteracting { get; private set; }
    private bool isShooting;

    [SerializeField]
    private GameObject cube;
    public GameObject curProjectile;
    private Vector3 mousePos;
    private Vector3 worldPos;
    // Start is called before the first frame update
    void Start()
    {
        InputHandler.instance.OnShootPressed += args => OnShoot();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Mouse.current.position.ReadValue();
        worldPos = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void OnShoot()
    {
        if (!isShooting)
        {
            isShooting = true;
            Instantiate(cube, worldPos, Quaternion.identity);
            isShooting = false;
        }
    }
}

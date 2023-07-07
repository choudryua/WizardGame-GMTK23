using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilarMovementController : MonoBehaviour
{
    public bool isInteracting { get; private set; }
    private bool isShooting;
    public GameObject curProjectile;
    // Start is called before the first frame update
    void Start()
    {
        InputHandler.instance.OnShootPressed += args => OnShoot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnShoot()
    {
        if (!isShooting)
        {
            isShooting = true;
        }
    }
}

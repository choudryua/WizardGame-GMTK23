using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField] GameObject _fireball;

    private void Start()
    {
        InputHandler.instance.OnShootPressed += args => OnShoot();
    }

    private void OnShoot()
    {
        Instantiate(_fireball, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z),Quaternion.identity);

    }
}

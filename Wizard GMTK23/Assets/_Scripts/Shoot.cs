using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField] GameObject _fireball;
    [SerializeField] GameObject _player;

    private bool ignore;




    private void Start()
    {
        InputHandler.instance.OnShootPressed += args => OnShoot();
        ignore = true;
        Physics2D.IgnoreLayerCollision(3, 10, true);

    }

    private void OnShoot()
    {
        if (GameObject.Find("FireBall(Clone)") != null)
        {
            print("fireball active");
        } else
        {
            Instantiate(_fireball, new Vector3(transform.position.x + .1f, transform.position.y + .2f, transform.position.z), Quaternion.identity);
            StartCoroutine(CameraShake.instance.Shake(.10f, .2f));
        }
    }
}

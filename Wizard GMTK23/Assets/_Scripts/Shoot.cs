using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField] GameObject _fireball;
    [SerializeField] GameObject _player;
    [SerializeField] private AudioClip _fireClip;
    [SerializeField] private AiMovement playerController;

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
        } else if(playerController.isRespawning == false)
        {
            Instantiate(_fireball, transform.position, Quaternion.identity);
            StartCoroutine(CameraShake.instance.Shake(.10f, .2f));
            SoundManager.instance.PlaySound(_fireClip);

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyControl>().Die();
            StartCoroutine(CameraShake.instance.Shake(.10f, .2f));
        }
    }
}

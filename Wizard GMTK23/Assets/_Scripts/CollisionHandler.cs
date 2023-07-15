using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float TimeToDestroy;
    private Animator anim;
    private string currentAnimaton;
    private bool isDestroyed;
    private EnemyControl enemyControl;
    [SerializeField] private AudioClip _Deathclip;

    [SerializeField] GameObject _ripple;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        isDestroyed = false;
        enemyControl = GetComponent<EnemyControl>();
    }



    private void FixedUpdate()
    {
        StartCoroutine(Destroy(TimeToDestroy));
        
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyControl>().Die();
            StartCoroutine(CameraShake.instance.Shake(.10f, .2f));
            Instantiate(_ripple, transform.position, Quaternion.identity);

        }
    }



    IEnumerator Destroy(float deathTime)
    {
        ChangeAnimationState("fireball");
        yield return new WaitForSeconds(deathTime);
        ChangeAnimationState("fireballdie");
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        anim.Play(newAnimation);
        currentAnimaton = newAnimation;
    }


}
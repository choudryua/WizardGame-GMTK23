using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float TimeToDestroy;
    private Animator anim;
    private string currentAnimaton;
    private bool isDestroyed;
    private EnemyControl enemyControl;
    [SerializeField] private AudioClip _Deathclip;


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
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Destroy(0));
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
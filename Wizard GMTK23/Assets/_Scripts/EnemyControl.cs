using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    [SerializeField] private GameObject _pointA;
    [SerializeField] private GameObject _pointB;
    [SerializeField] private float speed;
    [SerializeField] private AudioClip _Deathclip;
    [SerializeField] private ParticleSystem _expo;



    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private string currentAnimaton;
    private Transform currentPoint;
    private Animator anim;





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = _pointB.transform;
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == _pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2 (-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == _pointB.transform)
        {
            Flip();
            currentPoint = _pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == _pointA.transform)
        {
            Flip();
            currentPoint = _pointB.transform;
        }



        ChangeAnimationState("FlyingEnemy");

    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(_pointB.transform.position, 0.5f);
        Gizmos.DrawLine(_pointA.transform.position, _pointB.transform.position);

    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        anim.Play(newAnimation);
        currentAnimaton = newAnimation;
    }



    public void Die()
    {
        StartCoroutine(Died());
    }

    IEnumerator Died()
    {
        SoundManager.instance.PlaySound(_Deathclip);
        _expo.Play();
        ChangeAnimationState("blowUp");
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
}

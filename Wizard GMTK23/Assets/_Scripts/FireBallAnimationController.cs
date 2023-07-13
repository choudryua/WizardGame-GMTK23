using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallAnimationController : MonoBehaviour
{
    private Animator anim;

    private void OnDestroy()
    {
        anim.Play("fireballdie");
    }
}

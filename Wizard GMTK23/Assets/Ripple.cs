using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ripple : MonoBehaviour
{
    Renderer rend;
    public float _amount;
    public float _spread;
    public float _width;
    public float _alpha;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void FixedUpdate()
    {

        rend.material.SetFloat("_amount", _amount);
        rend.material.SetFloat("_spread", _spread);
        rend.material.SetFloat("_width", _width);
        rend.material.SetFloat("_alpha", _alpha);
    }
}

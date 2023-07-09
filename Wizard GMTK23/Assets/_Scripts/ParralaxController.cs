using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxController : MonoBehaviour
{
    Vector3 startPosition;
    public Camera cam;
    public float modifier;
    float width;
    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        startPosition = transform.position;
    }
    void Update()
    {
        Vector3 camOffset = Camera.main.transform.position * modifier;
        transform.position = startPosition + new Vector3(camOffset.x, camOffset.y, 0);
        if ((Camera.main.transform.position.x - transform.position.x) > width)
        {
            startPosition += new Vector3(width, 0, 0);
        }
        if ((Camera.main.transform.position.x - transform.position.x) < -width)
        {
            startPosition -= new Vector3(width, 0, 0);
        }
    }
}

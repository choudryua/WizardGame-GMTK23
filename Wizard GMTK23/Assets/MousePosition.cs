using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MousePosition : MonoBehaviour
{

    // FOLLOW DELAY
    //public float moveSpeed = 10;
    //void Update()
    //{
    //   Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
    //}




    //SMOOTH DAMP
    //public float maxMoveSpeed = 10;
    //public float smoothTime = 0.3f;
    //Vector2 currentVelocity;
    //void Update()
    //{
    //    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    transform.position = Vector2.SmoothDamp(transform.position, mousePosition, ref currentVelocity, smoothTime, maxMoveSpeed);
    //}


    // FOLLOW AT A DISTANCE
    //public float maxMoveSpeed = 10;
    //public float smoothTime = 0.3f;
    //public float minDistance = 2;
    //Vector2 currentVelocity;
    //voidUpdate()
    //{
    //   Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    // Offsets the target position so that the object keeps its distance.
    //   mousePosition += ((Vector2)transform.position - mousePosition).normalized * minDistance;
    //   transform.position = Vector2.SmoothDamp(transform.position, mousePosition, ref currentVelocity, smoothTime, maxMoveSpeed);
    //}

    public Rigidbody2D rb;
    public float turnSpeed = 45;
    public float moveSpeed = 5;
    void FixedUpdate()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePosition - transform.position;

        float angle = Vector2.SignedAngle(Vector2.right, direction);

        Vector3 targetRotation = new Vector3(0, 0, angle);

        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), turnSpeed * Time.deltaTime));

        rb.MovePosition(rb.position + ((Vector2)transform.right * moveSpeed * Time.deltaTime));
    }
}

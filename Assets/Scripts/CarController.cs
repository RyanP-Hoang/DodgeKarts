using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    Rigidbody2D rb;
    public float maxSpeed, turnSpeed;
    public Collider2D startLine, finishLine;
    public float startTime;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {

        if (Input.GetKey("w"))
        {
            rb.velocity = transform.up * maxSpeed;
        }
        if (Input.GetKey("s"))
        {
            rb.velocity = transform.up * -maxSpeed;
        }
        if (Input.GetKey("a"))
        {
            rb.angularVelocity = turnSpeed;
        }
        if (Input.GetKey("d"))
        {
            rb.angularVelocity = -turnSpeed;
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == startLine)
        {
            Debug.Log("start");
            startTime = Time.time;
        }
        if (other == finishLine)
        {
            Debug.Log("stop|" + (Time.time - startTime).ToString());
        }
    }
}
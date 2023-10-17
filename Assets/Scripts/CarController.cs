using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    public float roadLanes = 4f;

    //public int playerLane = 3;

    public Collider2D startLine, finishLine;
    public float startTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //Movement
    void FixedUpdate()
    {
        float y = Input.GetAxisRaw("Vertical") * Time.fixedDeltaTime * speed;

        Vector2 newPosition = rb.position + Vector2.up * y;

        newPosition.y = Mathf.Clamp(newPosition.y, -roadLanes, roadLanes);

        rb.MovePosition(newPosition);
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
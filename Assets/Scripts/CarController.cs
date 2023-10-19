using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    public float roadLanes = 2.5f;

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

 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }



}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    public float roadLanes = 4f;

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

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
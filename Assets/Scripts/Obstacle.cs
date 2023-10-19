using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float scrollSpeed = 5f;
    private float offset;
    private Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        scrollSpeed *= -1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -5f)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        offset = (Time.deltaTime * scrollSpeed);
        transform.Translate(new Vector2(offset, 0));
    }


}

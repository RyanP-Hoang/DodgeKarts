using System;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed = 5f;
    private float offset;
    
    public int length;

    

    private void Start()
    {
        scrollSpeed *= -1f;
    }

    void FixedUpdate()
    {
        offset = (Time.deltaTime * scrollSpeed) / 10f;
        transform.Translate(new Vector3(offset,0,0));
        
        if (transform.position.x <= -length)
        {
            transform.position = new Vector3(length, transform.position.y, transform.position.z);
        }
    }
}

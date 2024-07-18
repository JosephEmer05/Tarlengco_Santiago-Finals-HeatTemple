using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRise : MonoBehaviour
{
    public float speed = 5f;
    public float stopYPosition = 10f;
    private void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                if (transform.position.y < stopYPosition)
                    {
                        rb.velocity = Vector2.up * speed * Time.deltaTime;
                    }
                else
                    {
                        rb.velocity = Vector2.zero; // Stop movement when reaching the target Y position
                    }
            }
        
        else
        {
            // Use transform for simpler movement (without physics)
            if (transform.position.y < stopYPosition)
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
        }
    }
}

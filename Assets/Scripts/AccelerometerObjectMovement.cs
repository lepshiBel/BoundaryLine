using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerObjectMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float speed = 30.0f;
    private const float BorderPosition = 3f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 dir = Vector3.zero;
        dir.x = Input.acceleration.x;

        float positionX = rb.position.x + dir.x * speed * Time.deltaTime;

        positionX = Mathf.Clamp(positionX, -BorderPosition + (spriteRenderer.size.x / 2), BorderPosition - (spriteRenderer.size.x / 2));

        rb.MovePosition(new Vector2(positionX, rb.position.y));
    }
}
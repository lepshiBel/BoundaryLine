using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerObjectMovement : MonoBehaviour
{
    public GameObject side;

    private Camera camera;

    private float minX, maxX, minY, maxY;

    private Rigidbody2D rb;
    private float speed = 30.0f;

    private void Start()
    {
        camera = Camera.main;

        float objectSize = side.GetComponent<Renderer>().bounds.size.x;
        float cameraDistance = Mathf.Abs(transform.position.z - camera.transform.position.z);

        Vector3 cameraMin = camera.ViewportToWorldPoint(new Vector3(0, 0, cameraDistance));
        Vector3 cameraMax = camera.ViewportToWorldPoint(new Vector3(1, 1, cameraDistance));

        minX = cameraMin.x + objectSize;
        maxX = cameraMax.x - objectSize;

        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 dir = Vector3.zero;
        dir.x = Input.acceleration.x;

        float positionX = rb.position.x + dir.x * speed * Time.deltaTime;

        positionX = Mathf.Clamp(positionX, minX, maxX);

        rb.MovePosition(new Vector2(positionX, rb.position.y));
    }
}
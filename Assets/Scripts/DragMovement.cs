using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DragMovement : MonoBehaviour
{
    public GameObject side;
    private bool isDragging = false;
    private Vector3 startPosition;
    private Vector3 offset;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);           

            if (touch.phase == TouchPhase.Began)
            {
                isDragging = true;
                startPosition = transform.position;
                offset = startPosition - Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, rb.position.y, 10));
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, rb.position.y, 10)) + offset;

                float objectSize = side.GetComponent<Renderer>().bounds.size.x;
                float halfObjectWidth = transform.localScale.x / 1.81f;
                float leftBoundary = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10)).x + halfObjectWidth;
                float rightBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 10)).x - halfObjectWidth;
                newPosition.x = Mathf.Clamp(newPosition.x, leftBoundary, rightBoundary);

                transform.position = newPosition;
            }
            else if (touch.phase == TouchPhase.Ended && isDragging)
            {
                isDragging = false;
            }
        }
    }
}

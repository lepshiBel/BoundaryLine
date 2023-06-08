using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyLogic : MonoBehaviour
{
    private Rigidbody2D rbBallReflection;
    private Transform targetBallReflection;
    private Transform targetBall;
    private float speed = 6f;

    private void Start()
    {
        rbBallReflection = GameObject.FindGameObjectWithTag("BallReflection").GetComponent<Rigidbody2D>();
        targetBallReflection = GameObject.FindGameObjectWithTag("BallReflection").GetComponent<Transform>();
        targetBall = GameObject.FindGameObjectWithTag("Ball").GetComponent<Transform>();
    }

    private void Update()
    {
        rbBallReflection.MovePosition(new Vector2(targetBall.position.x, rbBallReflection.position.y));

        if (Vector2.Distance(transform.position, targetBall.position) < 8)
        {
            if (Mathf.Abs(targetBallReflection.position.x) < 2.7)
            {
                transform.position = Vector2.Lerp(transform.position, targetBallReflection.position, speed * Time.deltaTime);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BallMove : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private AudioSource audioSource;

    private Rigidbody2D rb;
    private float speed = 1.0f;
    private bool isActive;
    private float offsetX;
    private float offsetY;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0 && !isActive)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.tapCount > 1)
            {
                ActivateBallMoving();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerScoreTrigger")
        {
            gameManager.WinRound("enemy");
        }
        else if (collision.gameObject.tag == "EnemyScoreTrigger")
        {
            gameManager.WinRound("player");
        }

        if (collision.gameObject.tag == "BallSoundTrigger")
        {
            audioSource.PlayDelayed(0f);
        }
    }

    private void ActivateBallMoving()
    {
        while (Mathf.Abs(offsetX) < 350.0f && Mathf.Abs(offsetY) < 350.0f)
        {
            offsetX = Random.Range(-700.0f, 700.0f);
            offsetY = Random.Range(-700.0f, 700.0f);
        }

        isActive = true;
        transform.SetParent(null);
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddForce(new Vector2(offsetX, offsetY) * speed);
    }
}
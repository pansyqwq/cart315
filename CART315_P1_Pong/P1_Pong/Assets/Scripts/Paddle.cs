using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Paddle : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    public float speed = 10.0f;

    public Vector2 direction;

    public GameManager gameManager;//get data from game manager

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            ball.BounceY();
            gameManager.PaddleHit();
        }
    }

    private void Update()
    {
        // W = move up
        if (Keyboard.current.wKey.isPressed)
        {
            direction = Vector2.up;
        }
        // S = move down
        else if (Keyboard.current.sKey.isPressed)
        {
            direction = Vector2.down;
        }
        // Neither key = stop applying force
        else
        {
            direction = Vector2.zero;
        }
    }

    // FixedUpdate is called once per physics update
    private void FixedUpdate()
    {
        if (direction.sqrMagnitude == 0) return;

        _rigidBody.AddForce(direction * speed);
    }
}
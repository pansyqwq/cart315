using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class CourtBottom : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    public float speed = 10.0f;

    public Vector2 direction;

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
        }
    }

    // FixedUpdate is called once per physics update
    private void FixedUpdate()
    {
        if (direction.sqrMagnitude == 0) return;

        _rigidBody.AddForce(direction * speed);
    }
}
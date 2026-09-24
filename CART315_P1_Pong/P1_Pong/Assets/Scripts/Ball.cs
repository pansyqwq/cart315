using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    public float speed = 100.0f;
    public float bounceStrength = 1.2f;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        AddStartingForce();
    }


    public void BounceY()
    {
        Vector2 velocity = _rigidBody.linearVelocity;

        velocity.y = -velocity.y * bounceStrength;

        _rigidBody.linearVelocity = velocity;
    }

    public void ResetBall()
    {
        _rigidBody.linearVelocity = Vector2.zero;
        _rigidBody.angularVelocity = 0;
        transform.position = Vector3.zero;
    }

    public void AddStartingForce()
    {
        float x = -1.0f;//only going to the left

        float y = (Random.value < 0.5f ? -1.0f : 1.0f) * Random.Range(0.5f, 0.9f); //50% up or down

        Vector2 direction = new Vector2(x, y);

        _rigidBody.AddForce(direction * speed);
    }
}
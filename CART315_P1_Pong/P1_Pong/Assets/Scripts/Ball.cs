using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    public float speed = 100.0f;
    public float ballSpeed = 8f;
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

        // Reverse Y direction
        velocity.y = -velocity.y;

        // Keep the total speed constant
        velocity = velocity.normalized * ballSpeed;

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

    public void AddForce(Vector2 force)//anything can add force to this object, we'll need to access this in BouncySurface
    {
        _rigidBody.AddForce(force);
    }
}

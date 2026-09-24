using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleR : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    public float speed = 10.0f;

    public Vector2 direction;

    public GameManager gameManager;

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
        if (Keyboard.current.upArrowKey.isPressed)
        {
            direction = Vector2.up;
        }
        else if (Keyboard.current.downArrowKey.isPressed)
        {
            direction = Vector2.down;
        }
        else
        {
            direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (direction.sqrMagnitude == 0) return;

        _rigidBody.AddForce(direction * speed);
    }
}
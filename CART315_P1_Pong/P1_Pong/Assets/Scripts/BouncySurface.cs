using UnityEngine;

public class Bouncy : MonoBehaviour
{
    public float bonceStrength = 5f;

    private void OnCollisionEnter2D(Collision2D collision)// this will be called when anytime when objects collides 
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();//when collide, get ball, but we can't gerentee what collided with the surface is the ball

        //so we'll need to check that ball is not null, if it's null aka it collided with smth else
        if (ball != null)
        {
            Vector2 normal = collision.GetContact(0).normal;//get the first contact point of collision, normal = vector pointing away from that surface at that point
            ball.AddForce(normal * this.bonceStrength * -1); //bounceStrengh, similar to force, it's a multiplier, -1 for opposite dorection
        }

    }
}

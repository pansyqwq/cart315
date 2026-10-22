using UnityEngine;

public class Pipes : MonoBehaviour
{
    public Transform top;// transform stores object's position, rotation and scale
    public Transform bottom;
    public float speed = 5f;
    public float gap = 3f;

    private float leftEdge;//This variable stores the horizontal position of the left boundary used for destroying pipes.

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;// when the pipe moves to the edge and -1f position unity destroy it
        top.position += Vector3.up * gap / 2;//move the pipe upward
        bottom.position += Vector3.down * gap / 2;
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.left;// moving towards the left

        if (transform.position.x < leftEdge) {
            Destroy(gameObject);
        }
    }

}

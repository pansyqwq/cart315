using UnityEngine;

public class Player : MonoBehaviour
{
    public Sprite[] sprites;//stores the bird's animation
    public float strength = 5f;//jump strength
    public float gravity = -9.81f;// fall speed, need to be negative
    public float tilt = 5f;// control the bird's rotation 

    private SpriteRenderer spriteRenderer;//Stores the SpriteRenderer component responsible for displaying your bird's image.
    private Vector3 direction;//Vector3(x, y, z)
    private int spriteIndex;//Keeps track of which animation frame is currently displayed.

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();//Find the SpriteRenderer component attached to the same GameObject as this script.
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.20f, 0.20f); //InvokeRepeating() tells Unity to repeatedly execute a method at a specified interval.
                                                              //Call the AnimateSprite() method after 0.15 seconds.
                                                              //Keep calling it every 0.15 seconds.
    }

    private void OnEnable()//OnEnable() is called whenever the component becomes enabled and active.
    {
        Vector3 position = transform.position;//This creates a local variable called position.
        //It stores the bird's current position.

        position.y = 0f;//Changes only the Y coordinate to zero.
        transform.position = position;//Moves the bird to its updated position.
        direction = Vector3.zero;//The bird starts without any upward or downward velocity.
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) { 
            direction = Vector3.up * strength;//The bird now has an upward velocity of 5 Unity units per second.
        }

        // Apply gravity and update the position
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;//update the position 

        // Tilt the bird based on the direction, 
        Vector3 rotation = transform.eulerAngles;//This makes the bird point upward when jumping and downward when falling.
        rotation.z = direction.y * tilt;//rotating around the Z-axis makes the sprite rotate within the screen.
        transform.eulerAngles = rotation;
    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length){
            //sprites.Length tells you how many sprites are in your array.
            spriteIndex = 0;
        }

        if (spriteIndex < sprites.Length && spriteIndex >= 0) {
            spriteRenderer.sprite = sprites[spriteIndex];//display the sprite 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)// detecting collisions 
    {
        if (other.gameObject.CompareTag("Obstacle")) {
            GameManager.Instance.GameOver();
        } else if (other.gameObject.CompareTag("Scoring")) {
            GameManager.Instance.IncreaseScore();
        }
    }

}

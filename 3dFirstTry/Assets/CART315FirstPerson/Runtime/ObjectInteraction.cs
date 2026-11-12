
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectInteraction : MonoBehaviour
{
    [Header("Interaction Settings")]
    public Transform player;
    public float interactionDistance = 2f;
    public GameObject interactionPrompt;

    [Header("Audio Settings")]
    public AudioSource audioToStop;

    void Start()
    {
        if (interactionPrompt != null)
            interactionPrompt.SetActive(false);
    }

    void Update()
    {
        if (player == null) return;

        Collider objectCollider = GetComponent<Collider>();

        float distance;

        if (objectCollider != null)
        {
            Vector3 closestPoint =
                objectCollider.ClosestPoint(player.position);

            distance = Vector3.Distance(
                player.position,
                closestPoint
            );
        }
        else
        {
            distance = Vector3.Distance(
                player.position,
                transform.position
            );
        }

        bool playerNearby = distance <= interactionDistance;

        // Show interaction message
        if (interactionPrompt != null)
            interactionPrompt.SetActive(playerNearby);

        // Press E to interact
        if (playerNearby &&
            Keyboard.current != null &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            Interact();
        }
    }

    void Interact()
    {
        // Hide interaction message
        if (interactionPrompt != null)
            interactionPrompt.SetActive(false);

        // Stop the selected audio
        if (audioToStop != null)
        {
            audioToStop.Stop();
        }

        // Delete the object
        Destroy(gameObject);
    }
}

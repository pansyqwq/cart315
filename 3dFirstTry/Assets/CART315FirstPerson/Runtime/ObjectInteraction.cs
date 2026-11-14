

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

    [Header("Diary Collection")]
    public bool isDiaryPage = true;

    private static ObjectInteraction activeObject;

    private Collider objectCollider;
    private Renderer objectRenderer;

    void Start()
    {
        objectCollider = GetComponent<Collider>();
        objectRenderer = GetComponent<Renderer>();

        if (interactionPrompt != null)
            interactionPrompt.SetActive(false);
    }

    void Update()
    {
        if (player == null) return;

        if (activeObject == null ||
            !activeObject.isActiveAndEnabled ||
            !activeObject.IsPlayerNearby())
        {
            activeObject = null;
        }

        if (IsPlayerNearby())
        {
            if (activeObject == null ||
                GetDistance() < activeObject.GetDistance())
            {
                activeObject = this;
            }
        }

        if (activeObject == this)
        {
            if (interactionPrompt != null)
                interactionPrompt.SetActive(true);

            if (Keyboard.current != null &&
                Keyboard.current.eKey.wasPressedThisFrame)
            {
                Interact();
            }
        }
    }

    void LateUpdate()
    {
        if (interactionPrompt != null &&
            activeObject == null)
        {
            interactionPrompt.SetActive(false);
        }
    }

    float GetDistance()
    {
        if (objectCollider != null)
        {
            return Vector3.Distance(
                player.position,
                objectCollider.ClosestPoint(player.position)
            );
        }

        if (objectRenderer != null)
        {
            return Vector3.Distance(
                player.position,
                objectRenderer.bounds.ClosestPoint(player.position)
            );
        }

        return Vector3.Distance(
            player.position,
            transform.position
        );
    }

    bool IsPlayerNearby()
    {
        return player != null &&
               GetDistance() <= interactionDistance;
    }

    void Interact()
    {
        // Hide interaction prompt
        if (interactionPrompt != null)
            interactionPrompt.SetActive(false);

        // Stop selected audio
        if (audioToStop != null)
            audioToStop.Stop();

        // Add one diary page to the counter
        if (isDiaryPage)
        {
            if (DiaryCounter.Instance != null)
            {
                DiaryCounter.Instance.AddPage();
                Debug.Log("Diary page collected!");
            }
            else
            {
                Debug.LogWarning(
                    "DiaryCounter manager not found!"
                );
            }
        }

        // Clear active interaction
        activeObject = null;

        // Delete collected object
        Destroy(gameObject);
    }

    void OnDisable()
    {
        if (activeObject == this)
            activeObject = null;
    }
}

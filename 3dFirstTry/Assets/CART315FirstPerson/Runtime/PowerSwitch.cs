
using UnityEngine;
using UnityEngine.InputSystem;

public class PowerSwitch : MonoBehaviour
{
    [Header("Player")]
    public Transform player;
    public float interactionDistance = 3f;

    [Header("Emissive Panel")]
    public GameObject emissivePanel;

    [Header("Interaction UI")]
    public GameObject interactionPrompt;

    private bool isClosed = false;

    // Only one switch controls the shared prompt
    private static PowerSwitch activeSwitch;

    void Start()
    {
        if (interactionPrompt != null)
            interactionPrompt.SetActive(false);
    }

    void Update()
    {
        if (player == null || emissivePanel == null)
            return;

        // Switch must be glowing and not closed
        if (isClosed || !emissivePanel.activeInHierarchy)
        {
            if (activeSwitch == this)
                activeSwitch = null;

            return;
        }

        float distance = Vector3.Distance(
            player.position,
            transform.position
        );

        if (distance <= interactionDistance)
        {
            // Choose nearest available switch
            if (activeSwitch == null ||
                activeSwitch.isClosed ||
                !activeSwitch.emissivePanel.activeInHierarchy ||
                distance < Vector3.Distance(
                    player.position,
                    activeSwitch.transform.position))
            {
                activeSwitch = this;
            }
        }
        else if (activeSwitch == this)
        {
            activeSwitch = null;
        }
    }

    void LateUpdate()
    {
        // Only the active switch displays the prompt
        if (interactionPrompt != null)
        {
            interactionPrompt.SetActive(
                activeSwitch != null
            );
        }

        if (activeSwitch == this &&
            Keyboard.current != null &&
            Keyboard.current.cKey.wasPressedThisFrame)
        {
            CloseSwitch();
        }
    }

    void CloseSwitch()
    {
        if (isClosed)
            return;

        isClosed = true;

        // Turn off this switch's glowing panel
        if (emissivePanel != null)
            emissivePanel.SetActive(false);

        activeSwitch = null;

        if (interactionPrompt != null)
            interactionPrompt.SetActive(false);

        // Update objective counter
        if (DiaryCounter.Instance != null)
        {
            DiaryCounter.Instance.AddClosedSwitch();
        }
    }

    void OnDisable()
    {
        if (activeSwitch == this)
            activeSwitch = null;
    }
}

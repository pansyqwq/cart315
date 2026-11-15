
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DiaryCounter : MonoBehaviour
{
    public static DiaryCounter Instance;

    [Header("Diary Counter")]
    public int totalPages = 6;
    public int foundPages = 0;
    public Text counterText;

    [Header("Story Image")]
    public GameObject storyImage;

    [Header("Close Diary Instruction")]
    public GameObject closeDiaryText;

    [Header("Power Switch Objective")]
    public GameObject powerSwitchText;

    [Header("Emissive Panels")]
    public GameObject[] emissivePanels;

    [Header("Power Switch Counter")]
    public int totalSwitches = 3;
    public int closedSwitches = 0;
    public Text powerSwitchCounterText;

    private bool storyShown = false;

    void Awake()
    {
        Instance = this;

        if (storyImage != null)
            storyImage.SetActive(false);

        if (closeDiaryText != null)
            closeDiaryText.SetActive(false);

        if (powerSwitchText != null)
            powerSwitchText.SetActive(false);

        // Hide all emissive panels at game start
        foreach (GameObject panel in emissivePanels)
        {
            if (panel != null)
                panel.SetActive(false);
        }
    }

    void Start()
    {
        UpdateCounter();
        UpdatePowerSwitchCounter();
    }

    void Update()
    {
        if (storyImage != null &&
            storyImage.activeSelf &&
            Keyboard.current != null &&
            Keyboard.current.qKey.wasPressedThisFrame)
        {
            HideStory();
        }
    }

    public void AddPage()
    {
        if (foundPages >= totalPages)
            return;

        foundPages++;

        UpdateCounter();

        if (foundPages >= totalPages && !storyShown)
        {
            ShowStory();
        }
    }

    void UpdateCounter()
    {
        if (counterText != null)
        {
            counterText.text =
                "Diary Pages Found\n" +
                foundPages + "/" + totalPages;
        }
    }

    void ShowStory()
    {
        if (storyImage != null)
        {
            storyImage.SetActive(true);
            storyShown = true;
        }

        if (closeDiaryText != null)
            closeDiaryText.SetActive(true);
    }

    public void HideStory()
    {
        if (storyImage != null)
            storyImage.SetActive(false);

        if (closeDiaryText != null)
            closeDiaryText.SetActive(false);

        // Show the new objective
        if (powerSwitchText != null)
            powerSwitchText.SetActive(true);

        // Activate all 3 emissive panels
        foreach (GameObject panel in emissivePanels)
        {
            if (panel != null)
                panel.SetActive(true);
        }
    }

    public void AddClosedSwitch()
    {
        if (closedSwitches >= totalSwitches)
            return;

        closedSwitches++;

        UpdatePowerSwitchCounter();
    }

    void UpdatePowerSwitchCounter()
    {
        if (powerSwitchCounterText != null)
        {
            powerSwitchCounterText.text =
                "Power Switches Closed: " +
                closedSwitches + "/" + totalSwitches;
        }
    }
}

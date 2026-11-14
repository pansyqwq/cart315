
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

    private bool storyShown = false;

    void Awake()
    {
        Instance = this;

        if (storyImage != null)
            storyImage.SetActive(false);

        if (closeDiaryText != null)
            closeDiaryText.SetActive(false);

        // Hide the new objective at game start
        if (powerSwitchText != null)
            powerSwitchText.SetActive(false);
    }

    void Start()
    {
        UpdateCounter();
    }

    void Update()
    {
        // Press Q to close diary
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

        // Show the next objective after pressing Q
        if (powerSwitchText != null)
            powerSwitchText.SetActive(true);
    }
}

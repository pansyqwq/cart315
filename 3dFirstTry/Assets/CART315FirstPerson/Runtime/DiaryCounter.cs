
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

    private bool storyShown = false;

    void Awake()
    {
        Instance = this;

        // Hide both UI elements immediately
        if (storyImage != null)
            storyImage.SetActive(false);

        if (closeDiaryText != null)
            closeDiaryText.SetActive(false);
    }

    void Start()
    {
        UpdateCounter();
    }

    void Update()
    {
        // Press Q to close the diary
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

        // Show diary when all 6 pages are collected
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

        // Show close instruction
        if (closeDiaryText != null)
        {
            closeDiaryText.SetActive(true);
        }
    }

    public void HideStory()
    {
        // Hide story image
        if (storyImage != null)
        {
            storyImage.SetActive(false);
        }

        // Hide close instruction
        if (closeDiaryText != null)
        {
            closeDiaryText.SetActive(false);
        }
    }
}


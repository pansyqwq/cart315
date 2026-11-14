
using UnityEngine;
using UnityEngine.UI;

public class DiaryCounter : MonoBehaviour
{
    public static DiaryCounter Instance;

    public int totalPages = 6;
    public int foundPages = 0;

    public Text counterText;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateCounter();
    }

    public void AddPage()
    {
        if (foundPages >= totalPages)
            return;

        foundPages++;

        UpdateCounter();
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
}


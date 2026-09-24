using TMPro;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    private void Start()
    {
        finalScoreText.text = Score.finalScore.ToString();
    }
}
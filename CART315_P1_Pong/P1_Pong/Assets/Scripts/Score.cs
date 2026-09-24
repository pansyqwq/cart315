using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score = 0;

    public static int finalScore;

    public TextMeshProUGUI scoreText;

    public void IncreaseScore()
    {
        score++;
        UpdateScore();
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScore();
    }

    public void SaveFinalScore()
    {
        finalScore = score;
    }

    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
}
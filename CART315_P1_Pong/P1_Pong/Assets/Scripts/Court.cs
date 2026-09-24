using UnityEngine;
using UnityEngine.SceneManagement;

public class Court : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball == null) return;

        Debug.Log("Ball hit court!");

        Score score = FindFirstObjectByType<Score>();

        if (score != null)
        {
            score.SaveFinalScore();
        }

        SceneManager.LoadScene("gameOver");
    }
}
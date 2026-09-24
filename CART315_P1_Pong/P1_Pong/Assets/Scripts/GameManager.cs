using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Score score;
    public Ball ball;
    public GameStates gameState;

    private void Start()
    {
        StartRound();
    }

    public void StartRound()
    {
        ball.ResetBall();
        ball.AddStartingForce();
    }

    // Ball hits a paddle
    public void PaddleHit()
    {
        score.IncreaseScore();
    }

    // Ball leaves the court
    public void CourtTriggered(int courtId)
    {
        Debug.Log("Court triggered!");

        StartRound();
    }
}
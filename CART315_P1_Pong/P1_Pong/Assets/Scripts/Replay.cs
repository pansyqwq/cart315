using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    public void ReplayGame()
    {
      
        Score.finalScore = 0;

        SceneManager.LoadScene("SampleScene");
        Debug.Log("Replay button clicked!");
    }
}
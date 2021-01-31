using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Create a class to control how the score is displayed
// It helps reducing the processing needed 
public class ScoreManager : MonoBehaviour
{
    private int score = 0;

    private int highScore;

    // Persisting highscore
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public UpdateScore updateScore;

    // Start is called before the first frame update
    public void IncrementalScore(int num)
    {
        this.score += num;

        // Updating highscore
        if (this.score > highScore)
        {
            highScore = this.score;
            
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        updateScore?.Invoke(this.score);
    }

    // Update is called once per frame
    public delegate void UpdateScore(int score);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Score displayer
public class Score : MonoBehaviour
{
    public Text scoreNumber;

    // Option one to update the score display.

    /* public PlayerShip player;

    // Start is called before the first frame update
    private void Start()
    {
        scoreNumber = GetComponent<Text>();
        player =  GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShip>();
        
        scoreNumber.text = player.score.ToString();
    }

    // Update is called once per frame
    private void Update()
    {   
        scoreNumber.text = player.score.ToString();
    } */

    // Option two to update the score display (more effective).

    private ScoreManager _scoreManager;

    void OnEnable()
    {
        _scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        _scoreManager.updateScore += UpdateScore;
    }

    void OnDisable()
    {
        _scoreManager.updateScore -= UpdateScore;
    }

    void UpdateScore(int score)
    {
        scoreNumber.text = score.ToString();
    }
}
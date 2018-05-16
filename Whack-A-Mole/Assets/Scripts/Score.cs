using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text finalScoreText;

    private string _zero = "0";
    

    public void UpdateScore(int s)
    {
        scoreText.text = s.ToString();
    }

    public void NewGame()
    {
        scoreText.text = _zero;
    }

    public void GameOver(int s)
    {
        finalScoreText.text = s.ToString();
    }
}

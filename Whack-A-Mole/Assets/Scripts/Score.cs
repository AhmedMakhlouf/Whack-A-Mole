using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text finalScoreText;
    public Text[] topScoresText;

    private string zero = "0";
    private GameSave gameSave = new GameSave();
    private List<int> topScores = new List<int>();

    private void Awake()
    {
        topScores.AddRange(gameSave.Load());                
    }

    private void Start()
    {
        ShowTopScores();
    }

    public void UpdateScore(int s)
    {
        scoreText.text = s.ToString();
    }

    public void NewGame()
    {
        scoreText.text = zero;
    }

    public void GameOver(int s)
    {
        finalScoreText.text = s.ToString();
        
        CheckNewHighScore(s);
    }

    private void CheckNewHighScore(int s)
    {
        if (s < topScores[4] || topScores.Contains(s))
            return;

        topScores[4] = s;
        topScores.Sort();
        topScores.Reverse();

        gameSave.Save(topScores.ToArray());

        ShowTopScores();
    }

    private void ShowTopScores()
    {
        for (int i = 0; i < 5; i++)
        {
            topScoresText[i].text = topScores[i].ToString();
        }
    }
}

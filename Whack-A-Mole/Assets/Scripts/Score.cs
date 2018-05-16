using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text finalScoreText;
    public Text[] topScoresText;

    private string _zero = "0";
    private GameSave _gameSave = new GameSave();
    private List<int> _topScores = new List<int>();

    private void Awake()
    {
        _topScores.AddRange(_gameSave.Load());                
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
        scoreText.text = _zero;
    }

    public void GameOver(int s)
    {
        finalScoreText.text = s.ToString();
        
        CheckNewHighScore(s);
    }

    private void CheckNewHighScore(int s)
    {
        if (s < _topScores[4] || _topScores.Contains(s))
            return;

        _topScores[4] = s;
        _topScores.Sort();
        _topScores.Reverse();

        _gameSave.Save(_topScores.ToArray());

        ShowTopScores();
    }

    private void ShowTopScores()
    {
        for (int i = 0; i < 5; i++)
        {
            topScoresText[i].text = _topScores[i].ToString();
        }
    }
}

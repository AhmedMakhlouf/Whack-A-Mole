using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;

    private void Start()
    {
        scoreText.text = "0";
    }

    public void UpdateScore(int s)
    {
        scoreText.text = s.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiScoreText;
    public TextMeshProUGUI moneyText;

    public float scoreCount;
    public float hiScoreCount;

    public float moneyCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;

    public bool shouldDouble;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
        if(PlayerPrefs.HasKey("Money"))
        {
            moneyCount = PlayerPrefs.GetFloat("Money");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        if(scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);
        }

        scoreText.text = "Score: " + Mathf.Round (scoreCount);
        hiScoreText.text = "High Score: " + Mathf.Round(hiScoreCount);
        moneyText.text = "Money: " + Mathf.Round(moneyCount);
        
    }

    public void AddScore(int pointsToAdd)
    {
        if(shouldDouble)
        {
            pointsToAdd *= 2;
        }
        scoreCount += pointsToAdd;
    }

    public void AddMoney(int MoneyToAdd)
    {
        moneyCount += MoneyToAdd;
        PlayerPrefs.SetFloat("Money", moneyCount);
    }
}

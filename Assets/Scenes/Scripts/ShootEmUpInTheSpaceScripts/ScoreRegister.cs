using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreRegister : MonoBehaviour
{
    private static ScoreRegister instance;
    private int score;
    private int highScore;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    public static ScoreRegister Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ScoreRegister>();
                if (instance == null)
                {
                    GameObject scoreRegisterObj = new GameObject("ScoreRegister");
                    instance = scoreRegisterObj.AddComponent<ScoreRegister>();
                }
            }
            return instance;
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int newScore)
    {
        score = newScore;
        PlayerPrefs.SetInt("ScoreRegisterScore", score);
        PlayerPrefs.Save();
        UpdateScoreUI();
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        SetScore(score);
    }

    public int GetHighScore()
    {
        return highScore;
    }

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("ScoreRegisterHighScore", 0);
        UpdateHighScoreUI();
    }

    public void UpdateHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("ScoreRegisterHighScore", highScore);
            PlayerPrefs.Save();
        }
        UpdateHighScoreUI();
    }

    public void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void UpdateHighScoreUI()
    {
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }
}
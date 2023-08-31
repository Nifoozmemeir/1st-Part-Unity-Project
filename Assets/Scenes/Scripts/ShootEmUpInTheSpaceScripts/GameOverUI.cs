using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    private ScoreRegister scoreRegister;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI lowScoreText;
    [SerializeField] private TextMeshProUGUI highScoreBeatText;

    private void Start()
    {
        scoreRegister = FindObjectOfType<ScoreRegister>();
        UpdateUI();
    }

    private void UpdateUI()
    {
        int highScoreValue = PlayerPrefs.GetInt("ScoreRegisterHighScore", 0);
        highScoreText.text = highScoreValue.ToString();

        int scoreValue = PlayerPrefs.GetInt("ScoreRegisterScore", 0);
        scoreText.text = scoreValue.ToString();

        if (scoreValue < highScoreValue)
        {
            lowScoreText.gameObject.SetActive(true);
            highScoreBeatText.gameObject.SetActive(false);
        }
        else
        {
            lowScoreText.gameObject.SetActive(false);
            highScoreBeatText.gameObject.SetActive(true);
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("ShootEmUpInTheSpace");
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("MainMenuShootEmUp");
    }
}
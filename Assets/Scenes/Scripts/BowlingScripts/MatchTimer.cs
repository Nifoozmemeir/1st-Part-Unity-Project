using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MatchTimer : MonoBehaviour
{
    public float totalTime;
    private float currentTime;

    [SerializeField] private TextMeshProUGUI countdownText;

    void Start()
    {
        currentTime = totalTime;
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while (currentTime > 0)
        {
            countdownText.text = "Time Left: " + currentTime.ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;
        }

        ScoreManager.Instance.UpdateHighScore();
        Time.timeScale = 0f;
    }
}
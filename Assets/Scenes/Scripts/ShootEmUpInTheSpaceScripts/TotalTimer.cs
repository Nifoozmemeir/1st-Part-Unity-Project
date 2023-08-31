using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TotalTimer : MonoBehaviour
{
    private float startTime;
    private float elapsedTime;

    [SerializeField] private TextMeshProUGUI timerText;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        elapsedTime = Time.time - startTime;
        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        timerText.text = string.Format("Time Played: {0:00}:{1:00}", minutes, seconds);
    }
}
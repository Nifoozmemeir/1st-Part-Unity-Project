using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeCount : MonoBehaviour
{
    [SerializeField] private Image[] lifeImages;
    private int maxLives = 3;
    private int currentLives;

    private void Start()
    {
        currentLives = maxLives;
    }

    public void DecreaseLife()
    {
        if (currentLives > 0)
        {
            currentLives--;
            lifeImages[currentLives].gameObject.SetActive(false);

            if (currentLives == 0)
            {
                ScoreRegister.Instance.UpdateHighScore();
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
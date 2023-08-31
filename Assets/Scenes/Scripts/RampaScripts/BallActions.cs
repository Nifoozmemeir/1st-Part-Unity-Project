using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallActions : MonoBehaviour
{
    public GameObject ball;
    public Transform endPoint;
    public int score = 0;

    private bool gameEnded = false;

    public void UpdateScore(int value)
    {
        score += value;

        if (value > 0)
        {
            Debug.Log("¡Bien sumaste " + value + " puntos!");
        }
        else if (value < 0)
        {
            Debug.Log("Uy! perdiste " + Mathf.Abs(value) + " puntos...");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!gameEnded)
        {
            if (collision.transform == endPoint)
            {
                gameEnded = true;
                Debug.Log("¡Terminó el juego! Tu puntuación final es: " + score);
                Time.timeScale = 0f;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

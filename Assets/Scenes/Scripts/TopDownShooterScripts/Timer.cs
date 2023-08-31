using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = totalTime;
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while (currentTime > 0)
        {
            Debug.Log(currentTime);
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        Debug.Log("¡Sobreviviste! ¡Muy bien! Se terminó el juego");
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceBar : MonoBehaviour
{
    public Image barImage;
    public float fillSpeed;

    private bool isIncreasing = true;
    private BowlingBallController ballController;

    void Start()
    {
        ballController = GameObject.Find("Ball").GetComponent<BowlingBallController>();
    }

    void Update()
    {
        if (!ballController.isLaunched)
        {
            if (isIncreasing)
            {
                barImage.fillAmount += fillSpeed * Time.deltaTime;
                if (barImage.fillAmount >= 1f)
                    isIncreasing = false;
            }
            else
            {
                barImage.fillAmount -= fillSpeed * Time.deltaTime;
                if (barImage.fillAmount <= 0f)
                    isIncreasing = true;
            }
        }
    }
}
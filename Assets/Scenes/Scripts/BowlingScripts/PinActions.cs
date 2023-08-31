using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PinActions : MonoBehaviour
{
    private bool isDestroyed = false;
    public ParticleSystem particleSystem;
    public TextMeshProUGUI strikeText;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ball") && !isDestroyed)
        {
            isDestroyed = true;
            Destroy(gameObject);
            ScoreManager.Instance.AddScore(5);

            if (particleSystem != null)
            {
                particleSystem.Play();
            }

            CheckAllPinsDestroyed();
        }
    }

    private void CheckAllPinsDestroyed()
    {
        PinActions[] pins = transform.parent.GetComponentsInChildren<PinActions>();

        bool allPinsDestroyed = true;
        foreach (PinActions pin in pins)
        {
            if (!pin.isDestroyed)
            {
                allPinsDestroyed = false;
                break;
            }
        }

        if (allPinsDestroyed)
        {
            ScoreManager.Instance.AddScore(5 * (pins.Length - 1) + 25);

            if (strikeText != null)
            {
                strikeText.gameObject.SetActive(true);
                strikeText.text = "Congratulations! You made a strike, keep playing, time runs!!";
            }
        }
    }
}
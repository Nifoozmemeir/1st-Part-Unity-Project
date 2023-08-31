using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScore : MonoBehaviour
{
    public int scoreValue = 0;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject ball = collision.gameObject;

        BallActions ballActions = FindObjectOfType<BallActions>();

        if (ball.layer == LayerMask.NameToLayer("Ball"))
        {
            ballActions.UpdateScore(scoreValue);
            Destroy(gameObject);
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

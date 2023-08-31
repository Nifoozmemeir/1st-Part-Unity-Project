using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBallController : MonoBehaviour
{
    public float moveSpeed;
    [HideInInspector]
    public float launchForce;
    [HideInInspector]
    public float gravity = 9.8f;

    [HideInInspector]
    public bool isLaunched = false;
    private Rigidbody ballRigidbody;
    public ForceBar forceBar;
    private float timeElapsed = 0f;

    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody>();
        ballRigidbody.useGravity = false;
        ballRigidbody.isKinematic = true;
    }

    void Update()
    {
        if (!isLaunched)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            Vector3 movement = new Vector3(moveHorizontal, 0f, 0f) * moveSpeed * Time.deltaTime;
            transform.Translate(movement);

            timeElapsed += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                isLaunched = true;
                float fillAmount = forceBar.barImage.fillAmount;
                float launchForce = Mathf.Lerp(1f, 25f, fillAmount);
                LaunchBall(launchForce);
            }
            else if (timeElapsed >= 5f)
            {
                isLaunched = true;
                float fillAmount = forceBar.barImage.fillAmount;
                float launchForce = Mathf.Lerp(1f, 25f, fillAmount);
                LaunchBall(launchForce);
            }
        }
    }

    private void LaunchBall(float launchForce)
    {
        ballRigidbody.useGravity = true;
        ballRigidbody.isKinematic = false;
        ballRigidbody.AddForce(transform.forward * launchForce, ForceMode.Impulse);
    }

    public void ResetBall(Vector3 startPosition, Quaternion startRotation)
    {
        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;
        ballRigidbody.useGravity = false;
        ballRigidbody.isKinematic = true;
        transform.position = startPosition;
        transform.rotation = startRotation;
        isLaunched = false;
        timeElapsed = 0f;
    }

    public void EnableThrowing()
    {
        isLaunched = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitManager : MonoBehaviour
{
    private Vector3 ballStartPosition;
    private Quaternion ballStartRotation;

    private List<GameObject> activePins;
    private List<Vector3> initialPinPositions;
    private List<Quaternion> initialPinRotations;
    private BowlingBallController ballController;

    public GameObject bowlingPinPrefab;

    private void Start()
    {
        ballStartPosition = GameObject.Find("Ball").transform.position;
        ballStartRotation = GameObject.Find("Ball").transform.rotation;

        activePins = new List<GameObject>();
        initialPinPositions = new List<Vector3>();
        initialPinRotations = new List<Quaternion>();

        GameObject pinsParent = GameObject.Find("Pins");

        for (int i = 0; i < pinsParent.transform.childCount; i++)
        {
            GameObject pin = pinsParent.transform.GetChild(i).gameObject;
            initialPinPositions.Add(pin.transform.position);
            initialPinRotations.Add(pin.transform.rotation);
        }

        ballController = GameObject.Find("Ball").GetComponent<BowlingBallController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            ResetGame();
        }
    }

    private void ResetGame()
    {
        ballController.ResetBall(ballStartPosition, ballStartRotation);

        for (int i = 0; i < initialPinPositions.Count; i++)
        {
            Vector3 position = initialPinPositions[i];
            Quaternion rotation = initialPinRotations[i];

            GameObject pin = Instantiate(bowlingPinPrefab, position, rotation);
            activePins.Add(pin);
        }

        ballController.EnableThrowing();
    }
}
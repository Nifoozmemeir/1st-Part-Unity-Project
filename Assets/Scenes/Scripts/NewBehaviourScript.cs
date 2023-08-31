using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int frameCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        print("Hello World!! This is the Start Method");
    }

    // Update is called once per frame
    void Update()
    {
        print($"Hello World!! This is the Update Method: {frameCount}");
        frameCount++;
    }
}

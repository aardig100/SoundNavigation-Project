using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class PathRecord : MonoBehaviour
{
    float timeElapsed = 0.0f;
    float timeSinceLastPositionUpdate = 0.0f;
    float positionUpdateInterval = 0.5f;

    StreamWriter writer;

    // Start is called before the first frame update
    void OnEnable()
    {
        string path = Application.persistentDataPath + "/test_data.txt";
        writer = new StreamWriter(path, true);
    }

    private void OnDisable()
    {
        writer.Close();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        timeSinceLastPositionUpdate += Time.deltaTime;

        if (timeSinceLastPositionUpdate > positionUpdateInterval)
        {
            //Record position and elapsed time into file
            writer.WriteLine("Testing input: " + timeElapsed + " seconds have passed");

            timeSinceLastPositionUpdate = 0;
        }
        


    }
}

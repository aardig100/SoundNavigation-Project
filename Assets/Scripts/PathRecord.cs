using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using UnityEngine.SceneManagement;

public class PathRecord : MonoBehaviour
{
    float timeElapsed = 0.0f;
    float timeSinceLastPositionUpdate = 0.0f;
    float positionUpdateInterval = 0.5f;
    string path;
    StreamWriter writer;
    bool recording = true;

    [SerializeField]
    private CapsuleCollider characterController;

    // Start is called before the first frame update
    void Awake()
    {

        path = Application.persistentDataPath + "/test_data.txt";
        //Delete file if exists
        File.Delete(path);
        //Will create a new file
        writer = new StreamWriter(path, true);

        FlagPickup.OnFlagPickedUp += HandleFlagPickedUp;

        recording = true;
    }

    private void OnDisable()
    {
        writer.Close();
        FlagPickup.OnFlagPickedUp -= HandleFlagPickedUp;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        timeSinceLastPositionUpdate += Time.deltaTime;

        if (timeSinceLastPositionUpdate > positionUpdateInterval && recording)
        {
            //Record position and elapsed time into file
            writer.WriteLine(characterController.transform.position.x + "," + characterController.transform.position.z +  "," + timeElapsed);
            timeSinceLastPositionUpdate = 0;
        }
        


    }

    private void HandleFlagPickedUp()
    {

        if (recording)
        {
            recording = false;
            writer.WriteLine(timeElapsed);

            SceneManager.LoadScene(3);
        }



    }
}

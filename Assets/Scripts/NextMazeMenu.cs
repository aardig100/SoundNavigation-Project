using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class NextMazeMenu : MonoBehaviour
{
    [SerializeField]
    GameObject nextMazeButton;

    [SerializeField]
    GameObject finishedText;

    void OnEnable()
    {
        if(StateData.mazeNumber < 2)
        {
            nextMazeButton.SetActive(true);
            finishedText.SetActive(false);
        }
        else
        {
            nextMazeButton.SetActive(false);
            finishedText.SetActive(true);
        }
    }

    public void GoToNextMaze()
    {
        SceneManager.LoadScene(1 + StateData.mazeNumber);
    }
}

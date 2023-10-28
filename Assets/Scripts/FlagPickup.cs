using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(Rigidbody))]
public class FlagPickup : MonoBehaviour
{
    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Flag")
        {
            //Go to next maze scene
            StateData.mazeNumber += 1;
            SceneManager.LoadScene(7);
        }


    }

}

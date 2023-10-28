using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(Rigidbody))]
public class FlagPickup : MonoBehaviour
{
    public delegate void FlagPickedUp();
    public static event FlagPickedUp OnFlagPickedUp;

    bool repeatedCollision = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Flag")
        {
            //Go to next maze scene
            if (!repeatedCollision)
            {
                repeatedCollision = true;
                StateData.mazeNumber += 1;
                if (OnFlagPickedUp != null)
                    OnFlagPickedUp.Invoke();
                else
                    SceneManager.LoadScene(3);

            }
        }


    }

}

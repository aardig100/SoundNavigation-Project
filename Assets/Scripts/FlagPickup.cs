using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FlagPickup : MonoBehaviour
{
    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="flag")
        {
            //Go to next maze scene

        }


    }

}

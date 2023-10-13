using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject cameraObj;
    public float speed = 20f;

    public CharacterController charCntrl;

    void Start()
    {
        charCntrl = GetComponent<CharacterController>();
    }

    void Update()
    {
        
            //Get horizontal and Vertical movements
            float horComp = Input.GetAxis("Horizontal");
            float vertComp = Input.GetAxis("Vertical");

            Vector3 moveVect = Vector3.zero;

            Vector3 cameraLook = cameraObj.transform.forward;
            cameraLook.y = 0f;
            cameraLook = cameraLook.normalized;

            Vector3 forwardVect = cameraLook;
            Vector3 rightVect = Vector3.Cross(forwardVect, Vector3.up).normalized * -1;

            moveVect = rightVect * horComp + forwardVect * vertComp;

            moveVect *= speed * Time.deltaTime;

            charCntrl.SimpleMove(moveVect);
        
    }
}
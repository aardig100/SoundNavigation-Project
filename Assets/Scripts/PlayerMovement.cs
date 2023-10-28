using Oculus.Interaction.HandGrab;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public Transform orientation;
    public float speed = 20f;
    public float groundDrag;

    float horiInp;
    float vertiInp;

    Vector3 moveDir;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        
    }

    private void MyInput()
    {
        horiInp = Input.GetAxisRaw("Horizontal");
        vertiInp = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDir = orientation.forward * vertiInp + orientation.right * horiInp;

        rb.AddForce(moveDir.normalized * speed * 10f, ForceMode.Force);

        
    }

    private void SpeedControl() 
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > speed)
        {
            Vector3 limitVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitVel.x, rb.velocity.y, limitVel.z);
        }
    }

    void Update()
    {

        //Get horizontal and Vertical movements
        MyInput();
        SpeedControl();
        rb.drag = groundDrag;
        //Vector3 moveVect = Vector3.zero;

        //Vector3 cameraLook = cameraObj.transform.forward;
        //cameraLook.y = 0f;
        //cameraLook = cameraLook.normalized;

        //Vector3 forwardVect = cameraLook;
        //Vector3 rightVect = Vector3.Cross(forwardVect, Vector3.up).normalized * -1;

        //moveVect = rightVect * horComp + forwardVect * vertComp;

        //moveVect *= speed * Time.deltaTime;

        //charCntrl.SimpleMove(moveVect);

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }


}
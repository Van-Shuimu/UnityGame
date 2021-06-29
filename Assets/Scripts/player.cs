using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    
    public float moveSpeed = 4;
    public int jumPower = 15;
    public bool jumpflag = true;
    public float runSpeed = 8;
    public float mouseX = 100;
    public float mouseY = 150;
    public float maxAngle = 70;
    public float minAngle = -60;
    float angle = 0;
    public Transform cameraTransform;
    private Rigidbody rbody;
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        var mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        transform.rotation *= Quaternion.Euler(0, mouseInput.x * mouseX * Time.deltaTime, 0);
        angle = Mathf.Clamp(angle - mouseInput.y * mouseY * Time.deltaTime, minAngle, maxAngle);
        cameraTransform.localRotation = Quaternion.Euler(angle, 0, 0);
    }
    private void FixedUpdate()
    {
        var motionInput = transform.rotation * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        motionInput.x += rbody.velocity.x;
        motionInput.z += rbody.velocity.z;
        var speed = Input.GetButton("Fire3") ? runSpeed : moveSpeed;
        motionInput = Vector3.ClampMagnitude(motionInput, speed);
        motionInput.y = rbody.velocity.y;
        
        
        if (Input.GetKey(KeyCode.Space) && jumpflag)
        {
            motionInput.y = jumPower;
            jumpflag = false;    
        }
        rbody.velocity = motionInput;
    }

    private void OnCollisionEnter(Collision collision)
    {
        jumpflag = true;
    }
}


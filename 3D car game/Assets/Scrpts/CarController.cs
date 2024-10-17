using Palmmedia.ReportGenerator.Core.CodeAnalysis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider frontRightWheelCollider;
    public WheelCollider backRightWheelCollider;
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider backLeftWheelCollider;

    public Transform frontRightWheelTransform;
    public Transform backRightWheelTransform;
    public Transform frontLeftWheelTransform;
    public Transform backLeftWheelTransform;

    public Transform carCentreOffMassTrnsform;
    public Rigidbody rigidBody;
    public float motorForce=100f;
    public float steeringAngle = 30f;
    public float brakeForce = 1000f;

    

    float verticalInput;
    float horizontalInput;
    
    void Start()
    {
        rigidBody.centerOfMass=carCentreOffMassTrnsform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MotorForce();
        UpdateWheel();
        GetInput();
        Steering();
        AppliedBrake();
    }
    void GetInput()
    {
        verticalInput =Input.GetAxis("Vertical");
        horizontalInput =Input.GetAxis("Horizontal");

    }
    void AppliedBrake()
    {
        if (Input.GetKey(KeyCode.Space))
        {


            frontRightWheelCollider.brakeTorque = brakeForce;
            backRightWheelCollider.brakeTorque = brakeForce;
            frontLeftWheelCollider.brakeTorque = brakeForce;
            backLeftWheelCollider.brakeTorque = brakeForce;
        }
        else
        {
            frontRightWheelCollider.brakeTorque = 0f;
            backRightWheelCollider.brakeTorque = 0f;
            frontLeftWheelCollider.brakeTorque = 0f;
            backLeftWheelCollider.brakeTorque = 0f;

        }
    }
    void MotorForce()
    {
        frontRightWheelCollider.motorTorque = motorForce * verticalInput;
        frontLeftWheelCollider.motorTorque = motorForce * horizontalInput;
       
    }
    void Steering()
    {
        frontRightWheelCollider.steerAngle = steeringAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = steeringAngle* horizontalInput;
    }
    void UpdateWheel()
    {
        RotateWheel(frontRightWheelCollider , frontRightWheelTransform);
        RotateWheel(backRightWheelCollider, backRightWheelTransform);
        RotateWheel(frontLeftWheelCollider , frontLeftWheelTransform);
        RotateWheel(backLeftWheelCollider , backLeftWheelTransform);
    }
    void RotateWheel(WheelCollider wheelCollider , Transform transform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        transform.position = pos;
        transform.rotation = rot;
    }
}

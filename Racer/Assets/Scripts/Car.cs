using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Car : MonoBehaviour
{
    public WheelCollider wheelColliderLeftFront;
    public WheelCollider wheelColliderRightFront;
    public WheelCollider wheelColliderLeftRear;
    public WheelCollider wheelColliderRightRear;

    public Transform wheelLeftFront;
    public Transform wheelRightFront;
    public Transform wheelLeftRear;
    public Transform wheelRightRear;

    public float motorTorque = 300f;
    public float maxSteer = 20f;

    private void FixedUpdate()
    {
        //float verticalInput = Input.GetAxis("Vertical");
        //float torque = verticalInput * motorTorque;
        wheelColliderLeftRear.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        wheelColliderRightRear.motorTorque = Input.GetAxis("Vertical") * motorTorque;

        float horizontalInput = Input.GetAxis("Horizontal");
        float steer = horizontalInput * maxSteer;
        wheelColliderLeftFront.steerAngle = steer;
        wheelColliderRightFront.steerAngle = steer;
    }

    private void Update()
    {
        var pos = Vector3.zero;
        var rot = Quaternion.identity;

        wheelColliderLeftFront.GetWorldPose(out pos, out rot);
        wheelLeftFront.position = pos;
        wheelLeftFront.rotation = rot;

        wheelColliderRightFront.GetWorldPose(out pos, out rot);
        wheelRightFront.position = pos;
        wheelRightFront.rotation = rot * Quaternion.Euler(0, 180, 0);

        wheelColliderLeftRear.GetWorldPose(out pos, out rot);
        wheelLeftRear.position = pos;
        wheelLeftRear.rotation = rot;

        wheelColliderRightRear.GetWorldPose(out pos, out rot);
        wheelRightRear.position = pos;
        wheelRightRear.rotation = rot * Quaternion.Euler(0, 180, 0);
    }
}

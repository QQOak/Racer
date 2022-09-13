using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public bool Steer;
    public bool InvertSteer;
    public bool Power;

    public float SteerAngle { get; set; }
    public float Torque { get; set; }

    private WheelCollider wheelCollider;
    private Transform wheelTransform;

    // Start is called before the first frame update
    void Start()
    {
        this.wheelCollider = GetComponentInChildren<WheelCollider>();
        this.wheelTransform = GetComponentInChildren<MeshRenderer>().GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        this.UpdateWheelMeshPosition();
    }

    private void UpdateWheelMeshPosition()
    {
        this.wheelCollider.GetWorldPose(out Vector3 pos, out Quaternion rot);
        this.wheelTransform.SetPositionAndRotation(pos, rot);
    }

    private void FixedUpdate()
    {

        this.SetSteeringAngle();
        this.SetMotorTorque();
    }

    private void SetSteeringAngle()
    {
        if (Steer)
        {
            var angle = SteerAngle * (InvertSteer ? -1 : 1);
            wheelCollider.steerAngle = angle;
        }
    }

    private void SetMotorTorque()
    {
        if (Power)
        {
            wheelCollider.motorTorque = Torque;
        }
    }
}

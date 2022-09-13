using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CarController : MonoBehaviour
{
    public Transform centerOfMass;
    public float motorTorque = 1500f;
    public float maxSteer = 20f;

    public float Steer { get; set; }
    public float Throttle { get; set; }

    private Rigidbody _rigidBody;
    private Wheel[] wheels;

    private void Start()
    {
        this.wheels = GetComponentsInChildren<Wheel>();

        this._rigidBody = GetComponent<Rigidbody>();
        this._rigidBody.centerOfMass = centerOfMass.localPosition;
    }

    private void FixedUpdate()
    {
    }

    private void Update()
    {
        this.SetWheelSteeringAndToque();
    }

    private void SetWheelSteeringAndToque()
    {
        foreach (var wheel in wheels)
        {
            wheel.SteerAngle = Steer * maxSteer;
            wheel.Torque = Throttle * motorTorque;
        }
    }
}

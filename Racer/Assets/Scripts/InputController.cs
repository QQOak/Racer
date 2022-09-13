using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public string InputSteerAxis = "Horizontal";
    public string InputThrottleAxis = "Vertical";

    public float SteerInput { get; private set; }
    public float ThrottleInput { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SteerInput = Input.GetAxis(InputSteerAxis);
        ThrottleInput = Input.GetAxis(InputThrottleAxis);
    }
}

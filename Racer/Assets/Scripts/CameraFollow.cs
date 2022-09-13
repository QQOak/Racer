using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;

    public Vector3 Offset;
    public Vector3 EulerRotation;
    public float Damper;


    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = EulerRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null)
        {
            return;
        }

        transform.position = Vector3.Lerp(transform.position, Target.position + Offset, Damper * Time.deltaTime);
    }
}

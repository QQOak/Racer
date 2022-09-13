using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum ControlType
    {
        HumanInput,
        AI
    }

    public ControlType controlType = ControlType.HumanInput;

    public float BestLapTime { get; private set; } = Mathf.Infinity;

    public float LastLapTime { get; set; } = 0f;

    public float CurrentLapTime { get; private set; } = 0f;

    public int CurrentLap { get; private set; }

    private float lapTimeTimeStamp;
    private int lastCheckpointPassed = 0;

    private Transform checkpointsParent;
    private int checkpointsCount;
    private int checkpointLayer;
    private CarController carController;

    private void Awake()
    {
        checkpointsParent = GameObject.Find("Checkpoints").transform;
        checkpointsCount = checkpointsParent.childCount;
        checkpointLayer = LayerMask.NameToLayer("Checkpoint");
        carController = GetComponent<CarController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void StartLap()
    {
        Debug.Log("Start Lap");
        this.CurrentLap++;
        this.lastCheckpointPassed = 1;
        this.lapTimeTimeStamp = Time.time;
    }

    void EndLap()
    {
        Debug.Log("End Lap");
        this.LastLapTime = Time.time - lapTimeTimeStamp;
        BestLapTime = Mathf.Min(LastLapTime, BestLapTime);
        Debug.Log($"Last Lap was {BestLapTime}");
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.layer != checkpointLayer)
        {
            return;
        }

        Debug.Log($"Checkpoint {collider.gameObject.name}.  lastCheckpoint {lastCheckpointPassed}");

        if (collider.gameObject.name == "1")
        {
            if(lastCheckpointPassed == checkpointsCount)
            {
                EndLap();
            }

            if(CurrentLap == 0 || lastCheckpointPassed == checkpointsCount)
            {
                StartLap();
            }

            return;
        }

        if (collider.gameObject.name == (lastCheckpointPassed + 1).ToString())
        {
            lastCheckpointPassed++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        this.CurrentLapTime = lapTimeTimeStamp > 0 ? Time.time - lapTimeTimeStamp : 0;

        if(controlType == ControlType.HumanInput)
        {
            carController.Steer = GameManager.Instance.InputController.SteerInput;
            carController.Throttle = GameManager.Instance.InputController.ThrottleInput;
        }
    }
}

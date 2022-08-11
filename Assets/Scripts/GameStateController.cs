using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    Transform playerTransform;
    private float raceTime;
    private bool isRacing;
    private void Start()
    {
        Actions.RestartGame += ResetTime;
    }
    private void Update()
    {
        raceTime += Time.deltaTime;
        DisplayStatistics.Instance.ShowTime(raceTime);
    }
    private void ResetTime()
    {
        raceTime = 0;
    }
}

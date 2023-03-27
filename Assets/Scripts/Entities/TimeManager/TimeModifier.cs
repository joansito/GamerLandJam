using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeModifier : MonoBehaviour
{
   
    public TimeManagerV2 timeManager; // A reference to the TimeManager script
    public float slowDownFactor = 0.5f; // The factor by which to slow down time
    public float speedUpFactor = 2f; // The factor by which to speed up time

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Slow down time by the specified factor
            timeManager.SetTimeScale(timeManager.defaultTimeScale * slowDownFactor);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Speed up time by the specified factor
            timeManager.SetTimeScale(timeManager.defaultTimeScale * speedUpFactor);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // Reset time to the default speed
            timeManager.SetTimeScale(timeManager.defaultTimeScale);
        }
    }
}

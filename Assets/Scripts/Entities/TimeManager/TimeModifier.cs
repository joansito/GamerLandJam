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
        //Condiciales para probar, teclas 1,2 y 3
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SlowDownTime();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpeedUpTime();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ResetTimeScale();
        }
    }

    // Slows down time by the specified factor
    public void SlowDownTime()
    {
        timeManager.SetTimeScale(timeManager.defaultTimeScale * slowDownFactor);
    }

    // Speeds up time by the specified factor
    public void SpeedUpTime()
    {
        timeManager.SetTimeScale(timeManager.defaultTimeScale * speedUpFactor);
    }

    // Resets the time scale to the default value
    public void ResetTimeScale()
    {
        timeManager.SetTimeScale(timeManager.defaultTimeScale);
    }
}

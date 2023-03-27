using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Work : Action
{
    public Work()
    {
        actionName = "Sleep";
        health = 25f;
        satisfaction = 25f;
        leisure = 25f;
        active = false;
        timeToCompletion = Random.Range(480, 720); // Random porque sep
        timesCompleted = 0;
        timesCompletedToday = 0;

    }
}

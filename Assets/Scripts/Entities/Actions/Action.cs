using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour
{
    public string actionName;

    public float health;
    public float satisfaction;
    public float leisure;

    public bool active;

    public int timeToCompletion; // Minutes
    public int timesCompleted;
    public int timesCompletedToday;
}

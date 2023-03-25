using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour
{
    public float health;
    public float satisfaction;
    public float leisure;

    public bool active;
    public int timesCompleted;
    public int timesCompletedToday;

    public Player player;

    public abstract void DoAction();
}

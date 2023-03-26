using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WorldEvent
{
    public string name;
    public float healthModifier = 1;
    public float satisfactionModifier = 1;
    public float leisureModifier = 1;
    public List<Action> affectedActions = new List<Action>();
}

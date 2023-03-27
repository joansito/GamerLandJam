using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEvent
{
    public string name;
    public float healthModifier = 0;
    public float satisfactionModifier = 0;
    public float leisureModifier = 0;
    public List<string> affectedActions = new List<string>();

    public WorldEventType type;
}

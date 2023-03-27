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

    public WorldEvent(
        string name,
        float health,
        float satisfaction,
        float leisure,
        List<string> affectedActions,
        WorldEventType type
    )
    {
        this.name = name;
        this.healthModifier = health;
        this.satisfactionModifier = satisfaction;
        this.leisureModifier = leisure;
        this.affectedActions = affectedActions;
        this.type = type;
    }

    public static WorldEvent Normal()
    {
        return new WorldEvent("Normal", 0, 0, 0, new List<string>(), WorldEventType.StatusModifier);
    }
}

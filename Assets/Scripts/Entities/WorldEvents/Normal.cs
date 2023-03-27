using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal : WorldEvent
{
    public Normal()
    {
        name = "D�a normal";
        healthModifier = 1;
        satisfactionModifier = 1;
        leisureModifier = 1;
        affectedActions = new List<Action>();
        worldEventType = WorldEventType.StatusModifier;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEventFactory
{
    public static List<WorldEvent> GetWorldEvents(int day)
    {
        switch (day)
        {
            case 1:
                return new List<WorldEvent> { new WorldEvent("Normal", 20, 0, 0, new List<string> { "Comer" }, WorldEventType.ActionModifier) };
            default:
                return new List<WorldEvent>();
        }
    }
}

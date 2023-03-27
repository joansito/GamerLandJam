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
                return new List<WorldEvent>();
            default:
                return new List<WorldEvent>();
        }
    }
}

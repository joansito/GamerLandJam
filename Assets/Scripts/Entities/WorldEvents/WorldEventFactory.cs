using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEventFactory
{
    public static WorldEvent GetWorldEvent(int day)
    {
        switch (day)
        {
            case 1:
                return new Normal();
            default:
                return new Normal();
        }
    }
}

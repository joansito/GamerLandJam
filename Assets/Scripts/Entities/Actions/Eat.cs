using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : Action
{
    void Start()
    {
        actionName = "Comer";
        health = 0.05f;
        timeToCompletion = 60;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public List<Action> actions;
    public int day = 0;
    public int time = 0; // In minutes
    public bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void JumpToNextDay()
    {
        day += 1;
        time = 480;
    }

    public void JumpWorkTime()
    {
        time += 480;
    }

    private void UpdateTime()
    {
        if (paused) return;

        time = Mathf.CeilToInt(Time.deltaTime);
    }
}

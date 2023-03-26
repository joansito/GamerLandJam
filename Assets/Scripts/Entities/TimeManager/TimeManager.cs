using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float passiveHealthDecay = 0;
    public float passiveSatisfactionDecay = 0;
    public float passiveLeisureDecay = 0;

    public List<Action> actions;
    public Action activeAction;
    public int activeActionCompletionTime;

    public WorldEvent worldEvent;

    public int day = 0;
    public int time = 0; // In minutes
    public bool paused = false;

    public TextMesh dayText;
    public TextMesh timeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoAction(Action action)
    {
        if (!action.active) return;

        activeAction = action;
        activeActionCompletionTime = time + action.timeToCompletion;
    }

    public void JumpToNextDay()
    {
        day += 1;
        time = 480;
        worldEvent = WorldEventFactory.GetWorldEvent(day);

        if (day >= 28)
        {
            this.SendMessageUpwards(GameControllerEvents.Victory);
        }
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

    private void UpdateDateTimeText()
    {
        dayText.text = "Día " + day;

        int hours = Mathf.CeilToInt(time / 60);
        if (hours >= 24)
        {
            hours -= 24;
        }

        int minutes = time - (hours * 60);
        timeText.text = (hours < 10 ? "0" + hours : hours) + ":" + minutes;
    }
}

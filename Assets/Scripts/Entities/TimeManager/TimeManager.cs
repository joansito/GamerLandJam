using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float passiveHealthDecay = -0.1f;
    public float passiveSatisfactionDecay = -0.1f;
    public float passiveLeisureDecay = -0.1f;

    public List<Action> actions;
    public Action activeAction;
    public int activeActionCompletionTime;

    public List<WorldEvent> worldEvents = new List<WorldEvent>();

    Clock clock;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        clock = this.gameObject.GetComponent<Clock>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfActionCompleted();
    }

    private void FixedUpdate()
    {
        CalculateDecay();
    }

    public void DoAction(Action action)
    {
        if (!action.active) return;

        activeAction = action;
        activeActionCompletionTime =  clock.GetCurrentDayTime() + action.timeToCompletion;
    }

    private void CalculateDecay()
    {
        float healthDecay = passiveHealthDecay;
        float satisfactionDecay = passiveSatisfactionDecay;
        float leisureDecay = passiveLeisureDecay;

        // Apply Action efect
        if (activeAction != null)
        {
            if (activeAction.health != 0) healthDecay = activeAction.health;
            if (activeAction.satisfaction != 0) satisfactionDecay = activeAction.satisfaction;
            if (activeAction.leisure != 0) leisureDecay = activeAction.leisure;
        }

        // Apply WorldEvent modifiers
        if (HasWorldEvents())
        {
            WorldEvent statusEvent = worldEvents.Find(we => we.type == WorldEventType.StatusModifier);
            if (statusEvent != null)
            {
                healthDecay += statusEvent.healthModifier;
                satisfactionDecay += statusEvent.satisfactionModifier;
                leisureDecay += statusEvent.leisureModifier;
            }

            WorldEvent actionEvent = worldEvents.Find(we => we.type == WorldEventType.ActionModifier);
            if (actionEvent != null && activeAction != null)
            {
                if (actionEvent.affectedActions.Contains(activeAction.actionName))
                {
                    healthDecay += actionEvent.healthModifier;
                    satisfactionDecay += actionEvent.satisfactionModifier;
                    leisureDecay += actionEvent.leisureModifier;
                }
            }
        }

        player.UpdateStats(healthDecay, satisfactionDecay, leisureDecay);
    }

    private void UpdateActionStatusByWorldEvent()
    {
        if (!HasWorldEvents()) return;

        WorldEvent activationEvent = worldEvents.Find(we => we.type == WorldEventType.ActionActivation);
        if (activationEvent != null)
        {
            activationEvent.affectedActions.ForEach(actionName =>
            {
                Action action = actions.Find(ac => ac.name == actionName);
                action.active = true;
            });
        }

        WorldEvent deactivationEvent = worldEvents.Find(we => we.type == WorldEventType.ActionDeactivation);
        if (deactivationEvent != null)
        {
            deactivationEvent.affectedActions.ForEach(actionName =>
            {
                Action action = actions.Find(ac => ac.name == actionName);
                action.active = false;
            });
        }
    }

    private bool HasWorldEvents()
    {
        return worldEvents.Count > 0;
    }

    public void NewDay(int day)
    {
        worldEvents = WorldEventFactory.GetWorldEvents(day);
        UpdateActionStatusByWorldEvent();
    }

    private void CheckIfActionCompleted()
    {
        if (activeAction == null) return;

        if (activeActionCompletionTime <= clock.GetCurrentDayTime())
        {
            activeAction = null;
            activeActionCompletionTime = 0;
            player.ActionCompleted();
        }
    }
}

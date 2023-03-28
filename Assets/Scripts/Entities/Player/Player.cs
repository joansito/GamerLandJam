using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 100f;
    public float satisfaction = 100f;
    public float leisure = 100f;

    public HealthBar healthBar;
    public SatisfactionBar satisfactionBar;
    public LeisureBar leisureBar;

    private bool busy = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfDead();
    }


    public void UpdateStats(float health, float satisfaction, float leisure)
    {
        this.health += health;
        if (this.health > 100) this.health = 100;

        this.satisfaction += satisfaction;
        if (this.satisfaction > 100) this.satisfaction = 100;

        this.leisure += leisure;
        if (this.leisure > 100) this.leisure = 100;

        healthBar.UpdateBar();
        satisfactionBar.UpdateBar();
        leisureBar.UpdateBar();
    }

    private bool CheckIfDead()
    {
        if (health <= 0 || satisfaction <= 0 || leisure <= 0)
        {
            this.SendMessageUpwards(GameControllerEvents.Death);
            return true;
        }

        return false;
    }

    public void DoAction(Collider2D collision)
    {
        if (busy) return;
        if (Input.GetKeyDown(KeyCode.Q)) {
            Action action = collision.gameObject.GetComponent<Action>();
            this.SendMessageUpwards(TimeManagerEvents.DoAction, action);

            setPlayerBusy(true);
            // Activar animación correspondiente
        }
    }

    public void ActionCompleted()
    {
        busy = false;
    }

    public void setPlayerBusy(bool busy) {
        this.busy = busy;
    }
}

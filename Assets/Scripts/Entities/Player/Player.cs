using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 100;
    public float satisfaction = 100;
    public float leisure = 100;

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

    private void OnCollisionStay2D(Collision2D collision)
    {
        DoAction(collision);
    }

    public void UpdateStats(float health, float satisfaction, float leisure)
    {
        this.health += health;
        this.satisfaction += satisfaction;
        this.leisure += leisure;

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

    private void DoAction(Collision2D collision)
    {
        if (busy) return;
        if (Input.GetKeyDown(KeyCode.A)) {
            Action action = collision.gameObject.GetComponent<Action>();
            action.DoAction();

            busy = true;
        }
    }
}

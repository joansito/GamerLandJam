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
        Debug.Log(health);
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
            Debug.Log("dead");
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
            this.SendMessageUpwards(TimeManagerEvents.DoAction, action);

            busy = true;
            // Activar animación correspondiente
        }
    }
}

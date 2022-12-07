using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBox : MonoBehaviour
{
    public Data health;

    public HealthBar healthBar;

    public float timer = 0;

    private void Start()
    {
        health.currentHealh = health.maxHealth;
        healthBar.SetMaxHealth(health.maxHealth);
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy") && timer <= 0)
        {
            health.currentHealh -= 1;
            healthBar.SetHealth(health.currentHealh);
            timer = 1;
        }
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
}

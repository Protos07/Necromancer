using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Slider health_bar;
    public Slider health_bar_fill;
    public float damage;

    public float speed;

    void Start()
    {
        if (health_bar.value != health)
        {
            health_bar.value = health;
        }
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ApplyDamage(damage);

        }
        health_bar_fill.value = Mathf.Lerp(health_bar_fill.value, health_bar.value, speed);
    }

    public void ApplyDamage(float damage)
    {
        health_bar.value -= damage;
    }
}

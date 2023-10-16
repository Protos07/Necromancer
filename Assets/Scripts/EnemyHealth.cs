using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    private Collider2D col;
    public void Start()
    {
        Enemy enemy_cast = GetComponent<Enemy>();
    }
    public void Update()
    {        
        health_bar_fill.value = Mathf.Lerp(health_bar_fill.value, health_bar.value, speed);
             
        if (health_bar.value == 0)
        {
            Debug.Log("You killed him!");           

        }
    }
}
